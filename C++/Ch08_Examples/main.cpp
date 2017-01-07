#include <iostream>
#include <cstdlib> // to use srand
#include <ctime> // to use time()

using namespace std;

//void srand (int seed); // Takes number and sets as seed

int randRange(int low, int high)
{
    /*Slow since rand returns a large range and
    // not guaranteed to terminate

    while (1)
    {
        int rand_result = rand();
        if (rand_result >= low && rand_result <= high)
        {
            return rand_result;
        }
    }
    */
    //Add 1 to get total # of values in range, then add low
    //to bump lower bound of range up to the low value
    return rand() % (high - low + 1) + low;
}


int main()
{
    // time() returns Unix time = # seconds since 1/1/1970
    srand (time(NULL));
    //cout << rand() << '\n';
    for (int i = 0; i < 100; i++)
        cout << randRange(0,10) << endl;


}
