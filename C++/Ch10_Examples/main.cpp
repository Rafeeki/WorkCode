#include <iostream>
#include <cstdlib>
#include <ctime>
#include <iostream>

using namespace std;

int sumArray(int values[], int size);
void sort (int array[], int size);
int findSmallestRemainingElement(int array[], int size, int index);
void swap(int array[], int first_index, int second_index);
void displayArray(int array[], int size);

int main()
{
    /*Using for loops to create multiplication tables in 2D array
    int array[8][8];
    for (int i = 0; i < 8; i++ )
    {
        for (int j = 0; j < 8; j++ )
        {
            array[i][j] = i*j;
        }
    }

    cout << "Multiplication table:\n";
    for (int i = 0; i < 8; i++ )
    {
        for (int j = 0; j < 8; j++ )
        {
            cout << "[ " << i <<" ][ " << j <<" ] = ";
            cout << array [i][j] << " \n";
        }
    }
    */
    int values[10];
    /*
    for (int i = 0; i < 10; i++)
    {
        cout << "Enter value " << i  << ": ";
        cin >> values[i];
    }
    /cout << "Sum of values = " << sumArray(values,10) << endl;
    */
    srand( time(NULL) );
    for (int i = 0; i < 10; i++)
    {
        values[i] = rand() % 100;
    }
    cout << "Original array: ";
    displayArray(values, 10);
    cout << "\n";
    sort(values,10);
    cout << "Sorted array: ";
    displayArray(values, 10);
    cout << "\n";

}

void displayArray(int array[], int size)
{
    cout << "{";
    for (int i = 0; i < size; i++)
    {
        if (i != 0)
            cout << ", ";
        cout << array[i];
    }
    cout << "}";
}

int findSmallestRemainingElement(int array[], int size, int index)
{
    int index_of_smallest_value = index;
    for (int i = index + 1; i < size; i++)
    {
        if (array[i] < array[index_of_smallest_value])
        {
            index_of_smallest_value = i;
        }
    }
    return index_of_smallest_value;
}

void sort(int array[], int size)
{
    for (int i = 0; i < size; i++)
    {
        int index = findSmallestRemainingElement(array, size, i);
        swap(array, i, index);
    }

}

int sumArray(int values[], int size)
{
    int sum = 0;
    for (int i = 0; i < size; i++)
    {
        sum+= values[i];
    }
    return sum;
}

void swap(int array[], int first_index, int second_index)
{
    int temp = array[first_index];
    array[first_index] = array[second_index];
    array[second_index] = temp;
}
