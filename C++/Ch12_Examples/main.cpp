#include <iostream>

using namespace std;

void swap1(int left, int right)
{
    int temp = left;
    left = right;
    right = temp;
}

void swap2(int *p_left, int *p_right)
{
    int temp = *p_left;
    *p_left = *p_right;
    *p_right = temp;
}

void swap3(int& left, int& right)
{
    int temp = right;
    right = left;
    left = temp;
}

int main()
{
    /*
    int x = 5;
    int *p_x = & x; //assign memory address of variable x to pointer
    cout << "Memory address: " << p_x; //print out address
    cout << "\nValue at address: " << *p_x; //print out variable value
    */
    int x = 1, y = 2;
    swap1(x,y); //only swaps variable copies, not the actual variables
    cout << x << " " << y << endl;
    swap2(&x, &y); //actually swaps variable data b/c pointing at addresses
    cout << x << " " << y << endl;
    swap3(x, y); //swaps variable data using references instead of pointers
    cout << x << " " << y << endl;
}
