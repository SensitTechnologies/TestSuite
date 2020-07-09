/// <summary>
/// Generates a human-readable password
/// </summary>
/// <param name="numChars">number of letters that the password should contain</param>
/// <param name="numInts">number of numbers the password should contain</param>
/// <returns></returns>
private string GenerateReadablePassword(uint numChars = 8, uint numInts = 2)
{
	// Lists of consonants and vowels
	char[] consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
	char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

	// Create a stringbuilder to hold the new password.
	StringBuilder password = new StringBuilder();

	// Create a random number generator.
	Random random = new Random();

	// As long as we need to generate at least one more letter...
	while (0 != numChars)
	{
		// Add a consonant.
		password.Append(consonants[random.Next(consonants.Length)]);

		// Decrement length counter.
		numChars--;

		// If we need at least one more character...
		if (numChars > 0)
		{
			// Add a vowel.
			password.Append(vowels[random.Next(vowels.Length)]);
		}

		// Decrement counter.
		numChars--;
	}

	// As long as we need to generate at least one more number...
	for (uint i = numInts; i != 0; i--)
	{
		// Add a random number.
		password.Append(random.Next(0, 9));
	}

	return password.ToString();
}