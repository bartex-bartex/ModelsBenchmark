from flask import current_app
from sklearn.model_selection import train_test_split
import pandas as pd
import os

X_train = X_test = y_train = y_test = None

def load_data():
    global X_train, X_test, y_train, y_test

    if X_train is not None:
        return X_train, X_test, y_train, y_test
    
    train_file_path = os.path.join(current_app.config['DATA_PATH'], 'fashion-mnist_train.csv')
    test_file_path = os.path.join(current_app.config['DATA_PATH'], 'fashion-mnist_test.csv')

    train_data = pd.read_csv(train_file_path)
    test_data = pd.read_csv(test_file_path)

    X_train, y_train = train_data.drop(['label'], axis = 1), train_data['label']
    X_test, y_test = test_data.drop(['label'], axis = 1), test_data['label']

    return X_train, X_test, y_train, y_test
