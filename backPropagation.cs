using System;

public class Perceptron
{
  // Initializing the weights and bias for the first time
  float w11, w12, w21, w22, h1, h2, bh1, bh2, b = 0f;
  float fromh1 = 0f;
  float fromh2 = 0f;
  float errOut = 0f;
  // Setting learning rate to 0.1
  float learningR = 0.1f;

  w11 = (float) new Random().NextDouble();
  w12 = (float) new Random().NextDouble();
  w21 = (float) new Random().NextDouble();
  w22 = (float) new Random().NextDouble();
  h1 = (float) new Random().NextDouble();
  h2 = (float) new Random().NextDouble();
  bh1 = (float) new Random().NextDouble();
  bh2 = (float) new Random().NextDouble();
  b = (float) new Random().NextDouble();

  public void perceptAlgorithm(int input1, int input2, int target)
  {
    float prediction = predictResult(input1, input2)
    if( prediction != target)
    {
      errOut = ((float)target - prediction) * prediction * (1 - prediction);

      float errorh1 = (errOut * this.h1) * fromh1 * (1 - fromh1);
      float errorh2 = (errOut * this.h2) * fromh2 * (1 - fromh2);

      h1 +=  (learningR * errOut * fromh1);
      h2 +=  (learningR * errOut *fromh2);
      b +=  (learningR * errOut);

      w11 += (learningR * errorh1 * input1);
      w21 += (learningR * errorh1 * input2);
      w12 += (learningR * errorh2 * input1);
      w22 += (learningR * errorh2 * input2);
      bh1 += (learningR * errorh1);
      bh2 += (learningR * errorh2);

      // this.w1 += ( (float)input1 * (float)target * learningR);
      // this.w2 += ( (float)input2 * (float)target * learningR);
      // this.h1 += ( (float)input1 * (float)target * learningR);
      // this.h2 += ( (float)input2 * (float)target * learningR);
      // this.b +=  learningR * (float)target;  // We assume bias as 1 for the training set
    }
  }

    // Making a Activation Function
  public float activatonFunction(float prediction)
  {
        // if(prediction > 0)
        //     return 1;
        // else
        //     return -1;
        return 1/(1+ Math.Pow(2.71828182846, (-prediction));
  }

  // Training the model
  public void trainModel(int[,] trainingSet)
  {
    for(int i = 0; i < 500; i++)
    {
      int j = i%4;
      perceptAlgorithm(trainingSet[j,0], trainingSet[j,1], trainingSet[j,2]);
    }

    Console.WriteLine("\nAfter training the weight for the first input to first hidden is:  " + this.w11);
    Console.WriteLine("\nAfter training the weight for the first input to second hidden is:  " + this.w12);
    Console.WriteLine("\nAfter training the weight for the second input to first hidden is:  " + this.w21);
    Console.WriteLine("\nAfter training the weight for the second input to second hidden is:  " + this.w22);
    Console.WriteLine("\nAfter training the bias weight for first hidden neuron we obtained is:  " + this.bh1);
    Console.WriteLine("\nAfter training the bias weight for second hidden neuron we obtained is:  " + this.bh2);
    Console.WriteLine("\nAfter training the weight for the output neuron from first hidden is:  " + this.h1);
    Console.WriteLine("\nAfter training the weight for the output neuron from second hidden is:  " + this.h2);
    Console.WriteLine("\nAfter training the bias for output neuron we obtained is:  " + this.b);
  }

    // Function to predict the output
  public int predictResult(int input1, int input2)
  {
    float toh1 = ((float)input1*this.w11) +((float)input2*this.w21) + this.bh1; 

   float toh2 = ((float)input1*this.w12) +((float)input2*this.w22) + this.bh2;

   float finalNeuron = (toh1*this.h1) + (toh2*this.h2) + this.b;

    fromh1 = activatonFunction(toh1);
    fromh2 = activatonFunction(toh2);
    // float fromFinal = activatonFunction(finalNeuron);
    

   float predicted = activatonFunction(finalNeuron);
   return predicted;

    // float predicted = ((float)input1*this.w1) +((float)input1*this.h1) + ((float)input2*this.h2) + this.b;
    // return activatonFunction(predicted);
    
  }
}

class MainClass {
  public static void Main (string[] args) {

    Perceptron brain = new Perceptron();

    // DataSet to train the model
    int[,] trainingData = new int[4, 3] {{1, 1, -1}, {1, -1, 1}, {-1, 1, 1}, {-1, -1, -1} };

    brain.trainModel(trainingData);

    // Testing the model
    int result = brain.predictResult(1, -1);
    Console.WriteLine ("\nThe result for inputs (1, -1) is:  "+result);
  }
}