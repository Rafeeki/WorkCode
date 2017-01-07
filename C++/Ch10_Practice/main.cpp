#include <iostream>
#include <cstdlib>
#include <ctime>
#include <iostream>

using namespace std;

void displayArray(int array[], int size);
void insertion_sort (int array[], int size);
int findSmallestRemainingElement(int array[], int size, int index);
void swap(int array[], int first_index, int second_index);
bool sortedArray(int array[], int size);

int main()
{
    /*#2 Take in 50 values, print out high/low/avg & values
    int array[50];
    int max_, min_, avg_;

    for (int i = 0; i < 50; i++)
    {
        array[i] = rand() % 100;
    }
    cout << "Original array: ";
    displayArray(array, 50);
    cout << "\n";
    insertion_sort(array,50);
    max_ = array[49];
    min_ = array[0];
    avg_ = (array[49]+array[0])/2;
    cout << "Highest value: " << max_ << endl;
    cout << "Lowest value: " << min_ << endl;
    cout << "Average value: " << avg_ << endl;
    cout << "Sorted array: ";
    for (int i = 0; i < 50; i++)
    {
        cout << array[i] << endl;
    }
    */
    /*#3 Detect if array is sorted or not
    int array[10];

    for (int i = 0; i < 10; i++)
    {
        array[i] = rand() % 100;
    }
    cout << "Original array: ";
    //insertion_sort(array,10);
    //cout << "Sorted array: ";
    displayArray(array, 10);
    bool sorted = sortedArray(array, 10);
    if (sorted)
        cout << "\nThe original array was already sorted!\n";
    else
    {
        cout << "\nThe original array was not sorted, sorting now...\n";
        insertion_sort(array,10);
        displayArray(array,10);
    }
    */
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

void insertion_sort(int array[], int size)
{
    for (int i = 0; i < size; i++ )
    {
        int index = findSmallestRemainingElement(array, size, i);
        swap(array, i, index);
    }
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

bool sortedArray(int array[], int size)
{
    for (int i = 0; i < size; i++ )
    {
        int index = findSmallestRemainingElement(array, size, i);
        if (index != i)
        {
            return false;
            break;
        }
    }
    return true;
}

void swap(int array[], int first_index, int second_index)
{
    int temp = array[first_index];
    array[first_index] = array[second_index];
    array[second_index] = temp;
}
