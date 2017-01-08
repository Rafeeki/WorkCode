#include <iostream>
#include <string>

using namespace std;

int *growArray(int* p_values, int *size);
void printArray( int* p_values, int size, int elements_Set);

int main()
{
	/* Initializing a pointer 
	int *p_int = new int;
	cout << "New Location: " << &p_int << endl;
	delete p_int;
	p_int = NULL;
	cout << "New Location Released." << endl;
	*/
	/* Initializing a pointer with certain size
	int numbers[8];
	int *p_numbers = numbers;
	for (int i = 0; i < 8; ++i)
	{
		p_numbers[i] = i;
		cout << "Location: " << &p_numbers[i] << " Value: " << p_numbers[i] << endl;
	}
	delete[] p_numbers;
	*/
	/* Initializing a pointer of user-input size
	int count_of_numbers;
	cout << "Enter size of array: ";
	cin >> count_of_numbers;
	int *p_numbers = new int[ count_of_numbers];
	cout << "First Location: " << &p_numbers[0] << endl;
	cout << "Last Location: " << &p_numbers[count_of_numbers-1] << endl;
	delete[] p_numbers;
	*/
	int next_element = 0;
	int size = 10;
	int *p_values = new int[size]; //initialize pointer *p_values with size = 10
	int val;
	cout << "Please enter a number: ";
	cin >> val;
	while (val > 0)
	{
		if (size == next_element + 1)
		{
			p_values = growArray( p_values, &size);
		}
		p_values[next_element] = val; //store input val in consecutive p_values slots (1st iteration = 0)
		next_element++; //move iterator to the next slot (1st iteration -> 1)
		cout << "Current array values are: " << endl;
		printArray(p_values, size, next_element);
		cout << "Please enter a number (or 0 to exit): ";
		cin >> val;
	}
	delete [] p_values;
}

int *growArray(int* p_values, int *size)
{
	*size *= 2; //multiply input *size by 2
	int *p_new_values = new int[*size]; //create new pointer *p_new_values with doubled size
	for (int i = 0; i < *size; ++i)
	{
		p_new_values[i] = p_values[i]; //1st half of p_new_values = existing p_values, 2nd half is blank
	}
	delete [] p_values; //delete old p_values
	return p_new_values; //return new p_new_values with 2nd half empty
}

void printArray(int *p_values, int size, int elements_set)
{
	cout << "The total size of the array is: " << size << endl;
	cout << "Number of slots set so far: " << elements_set << endl;
	for (int i = 0; i < size; ++i)
	{
		cout << "p_values[" << i << "] = " << p_values[i] << endl;
	}
}
