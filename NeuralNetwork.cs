using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
public class NeuralNetwork : MonoBehaviour
{
	[SerializeField]
	private float[] inputData;

	[SerializeField]
	private NeuronLayer[] NeuronsLayer;
	[Space(40)]
	[SerializeField]
	private Neuron OutputNeuron;

	[System.Serializable]
	public struct NeuronLayer
	{
		public Neuron[] Neurons;
	}

	[System.Serializable]
	public struct Neuron
	{
		public float[] Weights;
		public float Bias;

		public float Output;

		private float Sigmoid(float S)
			=> 1.0f / (1.0f + Mathf.Pow(0.3679f, S));

		public void NeuronFunction(params float[] inputs)
		{
			float S = 0;
			for (int i = 0; i < Weights.Length; i++)
				S = S + Weights[i] * inputs[i];

			S = S + Bias;

			Output = Sigmoid(S);
		}
	}

	[ButtonMethod]
	public void NeuronNetworkWork()
	{
		bool enterLayer = true;
		for (int everyLayer = 0; everyLayer < NeuronsLayer.Length; everyLayer++)
		{
			for (int everyNeuronInLayer = 0; everyNeuronInLayer < NeuronsLayer[everyLayer].Neurons.Length; everyNeuronInLayer++)
			{
				if (enterLayer)
					NeuronsLayer[everyLayer].Neurons[everyNeuronInLayer].NeuronFunction(inputData);
				else
					NeuronsLayer[everyLayer--].Neurons[everyNeuronInLayer].NeuronFunction(inputData);
			}

			if (enterLayer)
				enterLayer = false;
		}

		float[] allOutputsFromLastLayer;
		if (NeuronsLayer.Length != 0)
		{
			allOutputsFromLastLayer = new float[NeuronsLayer[NeuronsLayer.Length - 1].Neurons.Length];
			for (int everyOutputFromLastLayer = 0; everyOutputFromLastLayer < allOutputsFromLastLayer.Length; everyOutputFromLastLayer++)
				allOutputsFromLastLayer[everyOutputFromLastLayer] = NeuronsLayer[NeuronsLayer.Length - 1].Neurons[everyOutputFromLastLayer].Output;

			OutputNeuron.NeuronFunction(allOutputsFromLastLayer);
		}
		else
			OutputNeuron.NeuronFunction(inputData);
	}

}
