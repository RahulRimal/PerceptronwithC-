using System;

public class Perceptron
{
  // Initializing the weights and bias for the first time
  float w1, w2, b = 0f;
  // Setting learning rate to 0.1
  float learningR = 0.1f;

  public void perceptAlgorithm(int input1, int input2, int target)
  {
    if(predictResult(input1, input2) != target)
    {
      this.w1 += ( (float)input1 * (float)target * learningR);
      this.w2 += ( (float)input2 * (float)target * learningR);
      this.b +=  learningR * (float)target;  // We assume bias as 1 for the training set
    }
  }

    // Making a Activation Function
  public int activatonFunction(float prediction)
  {
        if(prediction > 0)
            return 1;
        else
            return -1;
  }

  // Training the model
  public void trainModel(int[,] trainingSet)
  {
    for(int i = 0; i < 10; i++)
    {
      int j = i%4;
      perceptAlgorithm(trainingSet[j,0], trainingSet[j,1], trainingSet[j,2]);
    }

    Console.WriteLine("\nAfter training the weight for first the first input is:  " + this.w1);
    Console.WriteLine("\nAfter training the weight for second the first input is:  " + this.w2);
    Console.WriteLine("\nAfter training the bias we obtained is:  " + this.b);
  }

    // Function to predict the output
  public int predictResult(int input1, int input2)
  {
    float predicted = ((float)input1*this.w1) + ((float)input2*this.w2) + this.b;
    return activatonFunction(predicted);
    
  }
}

class MainClass {
  public static void Main (string[] args) {

    Perceptron brain = new Perceptron();

    // DataSet to train the model
    int[,] trainingData = new int[4, 3] {{1, 1, 1}, {1, -1, -1}, {-1, 1, -1}, {-1, -1, -1} };

    brain.trainModel(trainingData);

    // Testing the model
    int result = brain.predictResult(1, -1);
    Console.WriteLine ("\nThe result for inputs (1, -1) is:  "+result);
  }
}
