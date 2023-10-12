from flask import Flask, request, jsonify
import socket
import requests

app = Flask(__name__)

@app.route('/register', methods=['PUT'])
def register():
    data = request.json
    hostname = data.get('hostname')
    ip = data.get('ip')
    as_ip = data.get('as_ip')
    as_port = data.get('as_port')

    # DNS Registration message
    dns_msg = f"TYPE=A\nNAME={hostname}\nVALUE={ip}\nTTL=10\n"

    # Send the registration message to AS using UDP
    with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as s:
        s.sendto(dns_msg.encode(), (as_ip, int(as_port)))

    return '', 201

@app.route('/fibonacci', methods=['GET'])
def get_fibonacci():
    number = request.args.get('number')
    try:
        num = int(number)
        result = compute_fibonacci(num)
        return jsonify({"result": result}), 200
    except ValueError:
        return 'Bad format', 400

def compute_fibonacci(n):
    # A simple recursive implementation of Fibonacci
    if n <= 1:
        return n
    else:
        return compute_fibonacci(n-1) + compute_fibonacci(n-2)

if __name__ == '__main__':
    app.run(port=9090)
