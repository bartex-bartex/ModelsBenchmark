import json
import os
from . import db
from sklearn.neighbors import KNeighborsClassifier
from sklearn.metrics import accuracy_score


from flask import Blueprint, flash, g, redirect, render_template, request, url_for, current_app
from werkzeug.exceptions import abort

bp = Blueprint('benchmark', __name__, url_prefix='/api')


@bp.route('/models')
def models():
    file_path = os.path.join(current_app.config['DATA_PATH'], 'models.json')

    with open(file_path) as f:
        models = json.load(f)

    return models

@bp.route('/models/<model_name>')
def model_parameters(model_name):
    file_path = os.path.join(current_app.config['DATA_PATH'], 'modelsParameters.json')

    with open(file_path) as f:
        model_parameters = json.load(f)
    
    return model_parameters[model_name]

@bp.route('models/<model_name>/benchmark', methods=('POST',))
def benchmark(model_name):
    params = normalize_parameters(request.get_json())

    X_train, X_test, y_train, y_test = db.load_data()

    model = KNeighborsClassifier(**params)
    model.fit(X_train, y_train)
    y_pred = model.predict(X_test)

    accuracy = accuracy_score(y_test, y_pred) 

    return str(accuracy)

def normalize_parameters(params):
    keys_to_remove = []

    for key, value in params.items():
        if value == '':
            keys_to_remove.append(key)
        elif is_int(value):
            params[key] = int(value)
        elif is_float(value):
            params[key] = float(value)
    
    for key in keys_to_remove:
        del params[key]

    return params

def is_int(value):
    try:
        int(value)
        return True
    except ValueError:
        return False
    
def is_float(value):
    try:
        float(value)
        return True
    except ValueError:
        return False