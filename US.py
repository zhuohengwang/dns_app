from flask import Flask, request, jsonify
import socket

app = Flask(__name__)

@app.route('/fibonacci', methods=['GET'])
def fibonacci():
    hostname = request.args.get('hostname')
    fs_port = request.args.get('fs_port')
    number = request.args.get('number')
    as_ip = request.args.get('as_ip')
    as_port = request.args.get('as_port')

    if not all([hostname, fs_port, number, as_ip, as_port]):
        return 'Bad Request', 400

    # Resolve hostname
    target_ip = socket.gethostbyname(hostname)
    # TODO: Fetch Fibonacci number from FS using HTTP (e.g., using 'requests' library)
    
    return jsonify({"Fibonacci_Result": "Your Implementation Here"}), 200

if __name__ == '__main__':
    app.run(port=8080)
