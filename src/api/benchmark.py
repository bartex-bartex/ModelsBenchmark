import json
import os
from . import db
from sklearn.neighbors import KNeighborsClassifier, NearestCentroid
from sklearn.tree import DecisionTreeClassifier
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import accuracy_score
from sklearn.linear_model import LogisticRegression, LinearRegression, Perceptron, SGDClassifier
from sklearn.svm import SVC
from sklearn.gaussian_process import GaussianProcessClassifier

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

    model = None
    try:
        model = map_model(model_name, **params)
    except ValueError as e:
        return str(e), 400
    
    model.fit(X_train, y_train)
    y_pred = model.predict(X_test)

    accuracy = accuracy_score(y_test, y_pred) 

    return str(accuracy)

def map_model(model_name, **params):
    if model_name == "KNeighborsClassifier":
        return KNeighborsClassifier(**params)
    elif model_name == "DecisionTreeClassifier":
        return DecisionTreeClassifier(**params)
    elif model_name == "RandomForestClassifier":
        return RandomForestClassifier(**params)
    elif model_name == "LogisticRegression":
        return LogisticRegression(**params)
    elif model_name == "LinearRegression":
        return LinearRegression(**params)
    elif model_name == "Perceptron":
        return Perceptron(**params)
    elif model_name == "SGDClassifier":
        return SGDClassifier(**params)
    elif model_name == "SVC":
        return SVC(**params)
    elif model_name == "NearestCentroid":
        return NearestCentroid(**params)
    elif model_name == "GaussianProcessClassifier":
        return GaussianProcessClassifier(**params)
    else:
        raise ValueError(f"Model {model_name} not found")

def normalize_parameters(params):
    keys_to_remove = []

    for key, value in params.items():
        if value == '':
            keys_to_remove.append(key)
        elif is_int(value):
            params[key] = int(value)
        elif is_float(value):
            params[key] = float(value)
        elif is_bool(value):
            params[key] = value.lower() == 'true'
    
    for key in keys_to_remove:
        del params[key]

    # Seem important for me :-)
    params['n_jobs'] = -1

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
    
def is_bool(value):
    return value.lower() == 'true' or value.lower() == 'false'