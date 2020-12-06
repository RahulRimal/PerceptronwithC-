using System;

public class Adaline
{
  // Random rand = new Random();

  bool buffer = true;

  // Initializing the weights and bias for the first time
  float w1 = (float) new Random().NextDouble();
  float w2 = (float) new Random().NextDouble();
  float b = (float) new Random().NextDouble();

  // Setting learning rate to 0.1
  float learningR = 0.1f;


  // Setting up tendency to 0.01
  float tend = 0.01f;

  public void perceptAlgorithm(int input1, int input2, int target)
  {
    // Finding the net Input
    float netInput = predictResult(input1, input2);
    
    // Storing the old weights for the comparison
    float w1Old = this.w1;
    float w2Old = this.w2;
    float bOld = this.b;


    // Finding out the new weights
    this.w1 += ( (float)input1 * ((float)target - netInput) * learningR);
    this.w2 += ( (float)input2 * ((float)target - netInput) * learningR);
    this.b +=  learningR * ((float)target - netInput);  // We assume bias as 1 for the training set

    // Finding the changes in weights
    float w1Diff = this.w1 - w1Old;
    float w2Diff = this.w2 - w2Old;
    float bDiff = this.b - bOld;

    if(w1Diff > tend || w2Diff > tend || bDiff > tend)
    {
      buffer = false;
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
    int i = 0;
    while(buffer)
    {
      int j = i % 4;
      perceptAlgorithm(trainingSet[j,0], trainingSet[j,1], trainingSet[j,2]);
      i++;
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

    Adaline brain = new Adaline();

    // DataSet to train the model
    int[,] trainingData = new int[4, 3] {{1, 1, 1}, {1, -1, -1}, {-1, 1, -1}, {-1, -1, -1} };

    brain.trainModel(trainingData);

    // Testing the model
    int result = brain.predictResult(1, -1);
    Console.WriteLine ("\nThe result for inputs (1, -1) is:  "+result);
  }
}
