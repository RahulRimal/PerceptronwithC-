using System;

public class Hebbian
{
  // Initializing the weights and bias for the first time
  int w1, w2, b = 0;

  public void hebbAlgorithm(int input1, int input2, int target)
  {
    this.w1 += ( input1 * target);
    this.w2 += ( input2 * target);
    this.b +=  target;  // We assume bias as 1 for the training set
  }


    // Making a Activation Function
  public int activatonFunction(int prediction)
  {
        if(prediction >= 0)
            return 1;
        else
            return -1;
  }

  // Training the model
  public void trainModel(int[,] trainingSet)
  {
    for(int i = 0; i < 4; i++)
    {
      hebbAlgorithm(trainingSet[i,0], trainingSet[i,1], trainingSet[i,2]);
    }

    Console.WriteLine("\nAfter training the weight for first the first input is:  " + this.w1);
    Console.WriteLine("\nAfter training the weight for second the first input is:  " + this.w2);
    Console.WriteLine("\nAfter training the bias we obtained is:  " + this.b);
  }

    // Function to predict the output
  public int predictResult(int input1, int input2)
  {
    int predicted = (input1*this.w1) + (input2*this.w2) + this.b;
    return activatonFunction(predicted);

  }

}

class MainClass {
  public static void Main (string[] args) {

    Hebbian hebb = new Hebbian();

    // DataSet to train the model
    int[,] trainingData = new int[4, 3] {{1, 1, 1}, {1, -1, -1}, {-1, 1, -1}, {-1, -1, -1} };

    // Training the model
    hebb.trainModel(trainingData);

    // Testing the model
    int result = hebb.predictResult(1, -1);
    Console.WriteLine ("\nThe result for inputs (1, -1) is:  "+result);
  }
}
