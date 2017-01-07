#include <iostream>
#include <string>

using namespace std;

int main()
{
    /* Braces vs. non-braces
    if ( 5 > 10 )
    { //all code within braces is conditional on if
        cout << "Five is less than then!" << endl;
        cout << "I hope this computer is working right!\n";
    }
    if ( 5 > 10 ) //no braces mean second line executes!
        cout << "Five is less than then!" << endl;
        cout << "I hope this computer is working right!\n";
    */

    /* First conditional logic on user input!
    int x;
    cout << "Enter a number: ";
    cin >> x;
    if ( x < 10 )
    {
        cout << "You entered a value less than 10" << '\n';
    }
    */

    /* Boolean variable & ELSE
    int x;
    cin >> x;
    bool is_x_two = x == 2;
    if (is_x_two )
        cout << "You entered two!\n";
    else
        cout << "You didn't enter two...\n";
    */

    /* String comparisons (passwords)
    string pword;
    cout << "Enter your password: \n";
    getline(cin,pword,'\n');
    if (pword == "xyzzy")
        cout << "Access allowed!\n";
    else
    {
        cout << "Bad password. Access Denied!\n";
        return 0; //convenient way of stopping program
    }
    */

    // Short-circuiting logic to avoid nested ifs
    int x;
    cout << "Enter a value not equal to zero: \n";
    cin >> x;
    if (x !=0 && 10/x <2 )
        cout << "10/x is less than 2";
    else
        cout << "You had one job...";
}
