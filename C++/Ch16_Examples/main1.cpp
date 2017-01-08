#include <iostream>

using namespace std;

void recurse(int count) //each call gets its own count
{
	cout << count << endl;
	recurse(count + 1);
}

int main()
{
	recurse(1);
}
