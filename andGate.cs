using System;


public class Perceptron
{
  Random rand = new Random();
    float[] weights = new float[2];
    int maxVal = 1;
    int minVal = 0;
    float bias = -1f;
    float learningRate = 0.1f;


    public Perceptron()
    {
        //   Initializing the weigth with random values between -1 and 1;
        for(int i = 0; i < weights.Length; i++)
        {
            weights[i] = (float) rand.NextDouble();
        }
    }

        //  Prediction by the model
    public int guess(float[] inputs)
    {
        float sum = 0;
        for(int i = 0; i < weights.Length; i++)
        {
            sum += inputs[i]*weights[i] + bias;
        }
        int output = sine(sum);
        return output;
    }

    int sine(float n)
    {
        if(n >= 0)
            return 1;
        else
            return 0;
    }

    public void train(float[] inputs, int target)
    {
        int guessed = guess(inputs);
        int error = target - guessed;

        //  Adjusting the weights

        for(int i = 0; i < weights.Length; i++)
        {
            weights[i] += error * inputs[i] * learningRate;
        }

    }

}

public class Training
{
    Random random = new Random();

    public float x;
    public float y;

    int maxVal = 1;
    int minVal = -1;

    public int target;

    public Training()
    {
        //  Generating random values for the training.
        x = (float) random.NextDouble() * ((maxVal - minVal) - minVal);
        y = (float) random.NextDouble() * ((maxVal - minVal) - minVal);

        //  Trying the logic of AND Gate.
        if(x >= 0 && y >= 0)
            target = 1;
        else
            target = 0;
    }


}



class MainClass {
  public static void Main (string[] args)
  {
    Perceptron percept = new Perceptron();

    trainTheModel(percept);

    float[] inputs = {1f, 1f};

    Console.WriteLine(percept.guess(inputs));

  }

  public static void trainTheModel( Perceptron percept)
  {
    // Perceptron percept = new Perceptron();

    //  Creating the population of 100 pairs
    Training[] points = new Training[100];

    for(int i = 0; i < points.Length; i++)
    {
        points[i] = new Training();
    }
      
    foreach (Training point in points)
    {
        float[] trainingPoint = {point.x, point.y};
        percept.train(trainingPoint, point.target);
    }
  }
}