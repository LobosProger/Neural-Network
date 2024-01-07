# Neural-Network
### Neural Network Simulation

This repository contains a simple Unity script that simulates the behavior of a neural network. Please note that this code does not implement the training of the neural network based on test data; it serves as a basic illustration of neural network functionality.

### How It Works

The script defines a `NeuralNetwork` class, which includes the following components:

- **Input Data**: An array of floats representing input data.
- **Neuron Layers**: An array of neuron layers, each containing an array of neurons.
- **Output Neuron**: A single output neuron.
- **Neuron Struct**: Represents an individual neuron with weights, bias, and output.

### Neural Network Operation

The `NeuronNetworkWork` method is responsible for the neural network's operation. It iterates through each layer and neuron, applying the sigmoid activation function to compute the output of each neuron based on the provided input data.

### Activation Function

The activation function used in this simulation is the sigmoid function.

### How to Use

To use this script, you can modify the `inputData` array with your desired input values and observe the simulated neural network's output.
