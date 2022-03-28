using System;

public class Employee
{
	public Employee(string firstName, string lastName, string position)
	{
		FirstName = firstName;
		LastName = lastName;
		Position = position;
	}

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Position { get; set; }
}
