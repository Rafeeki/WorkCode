#include <iostream>

using namespace std;

int pow(int x, int y)
{
	if(y > 0)
		return x * pow(x, y-1);
	else
		return 1;
}

int main()
{
	int base, exp, ans;
	cout << "Enter your base: ";
	cin >> base;
	cout << "Enter your exponent: ";
	cin >> exp;
	ans = pow(base, exp);
	cout << "Your answer, using recursion = " << ans << endl;
}
