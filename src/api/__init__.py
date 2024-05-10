import os
from flask import Flask

def create_app():
    app = Flask(__name__)
    basedir = os.path.abspath(os.path.dirname(__file__))
    app.config['DATA_PATH'] = os.path.join(basedir, 'data')
    app.json.sort_keys = False

    # @app.route('/hello')
    # def hello():
    #     return 'Hello, World!'
    
    from . import benchmark
    app.register_blueprint(benchmark.bp)

    return app