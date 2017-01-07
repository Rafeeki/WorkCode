#include <iostream>

using namespace std;

bool isDivisible(int num, int div)
{
    //Math to determine if num is a Prime, involving mod
    return num % div == 0;
}
bool isPrime(int num)
{
    for (int i = 2; i < num; i++)
    {
        if (isDivisible(num, i))
        {
            return false;
        }
    }
    return true;
}

int main()
{
    for (int i = 1; i < 100; i++)
    {
        if (isPrime(i))
        {
            cout << i << endl;
        }
    }
}
