// See https://aka.ms/new-console-template for more information

const int MaxCheckCount = 50;
const int NumPrisoners = 100;
const int SequenceCount = 100;

int numSuccesses = 0;
// Do a sequence of 100 of these to see if the average 30% success holds up over many runs.
for (int seqCnt = 0; seqCnt < SequenceCount; seqCnt++)
{
    int[] prisonerNumberArray = new int[NumPrisoners];

    HashSet<int> alreadyContainsNumber = new HashSet<int>();

    // Not efficient, just fill up an array. Could probably do a randomized swap of a list that would be more efficient but who cares for this demo.
    // No need for efficiency unless you make # of prisoners very large.
    Random random = new();
    for (int i = 0; i < NumPrisoners; i++)
    {
        while (true)
        {
            int newRndValue = random.Next(1, NumPrisoners + 1);
            if (!alreadyContainsNumber.Contains(newRndValue))
            {
                prisonerNumberArray[i] = newRndValue;
                alreadyContainsNumber.Add(newRndValue);
                break;
            }
        }
    }

    bool succeeded = true;
    for (int prisoner = 1; prisoner <= NumPrisoners; prisoner++)
    {
        int currentCount = 0;
        int nextPrisonerBoxToCheck = prisoner;
        while (currentCount < MaxCheckCount && prisonerNumberArray[nextPrisonerBoxToCheck - 1] != prisoner)
        {
            // Set the next prisoner box to check to be whatever the randomly assigned value in the array is.
            nextPrisonerBoxToCheck = prisonerNumberArray[nextPrisonerBoxToCheck - 1];
            currentCount++;
        }

        if (currentCount == MaxCheckCount)
        {
            succeeded = false;
            break;
        }
    }

    if (succeeded)
    {
        numSuccesses++;
    }
}


string result = $"Number of successes: {numSuccesses} out of {SequenceCount}";
Console.WriteLine(result);