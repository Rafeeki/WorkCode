#include <iostream>

using namespace std;

// Functions must be declared before the main!
int add (int x, int y)
{
    return x + y;
}

int count_fxn_calls = 0;

void fun()
{
    count_fxn_calls++;
}

int main()
{
    /* First function call!
    int arg1, arg2, sum;
    cout << "Enter a number to be added: " << endl;
    cin >> arg1;
    cout << "Enter a number to be added: " << endl;
    cin >> arg2;
    sum = add(arg1, arg2);
    cout << "Your sum is: " << sum;
    return 0;
    */

    /*Global variables
    fun();
    fun();
    fun();
    cout << "Function fun was called " << count_fxn_calls << " times!";
    */
}

