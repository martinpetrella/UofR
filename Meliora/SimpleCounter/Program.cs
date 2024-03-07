var count = 1;

// Default parameters
var nursingFactorDefault = 3;
var melioraFactorDefault = 7;
var maxCountDefault = 50;
var intervalDefault = 1;

// Working parameters
var nursingFactor = nursingFactorDefault;
var melioraFactor = melioraFactorDefault;
var maxCount = maxCountDefault;
var interval = intervalDefault;

// Set working parameters from command line
// For the sake of simplicity and code challenge deadline
// I'm not going to validate command line arguments
// but will simply assume the values are reasonable
// positive integers
if (Environment.GetCommandLineArgs().Length == 5)
{
    nursingFactor = int.Parse(Environment.GetCommandLineArgs()[1]);
    melioraFactor = int.Parse(Environment.GetCommandLineArgs()[2]);
    maxCount = int.Parse(Environment.GetCommandLineArgs()[3]);
    interval = int.Parse(Environment.GetCommandLineArgs()[4]);
}

// Count until max is reached
while (count <= maxCount)
{
    // Set output message to current count
    var message = string.Concat(count.ToString(), " ");

    // Append Nursing to message when count is a multiple of nursingFactor
    if ((count % nursingFactor) == 0)
    {
        message = string.Concat(message, "Nursing ");
    }

    // Append Meliora to message when count is a multiple of melioraFactor
    if ((count % melioraFactor) == 0)
    {
        message = string.Concat(message, "Meliora");
    }

    Console.WriteLine(message);

    count = count + 1;

    Thread.Sleep(interval * 1000);
}