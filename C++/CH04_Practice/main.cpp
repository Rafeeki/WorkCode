#include <iostream>
#include <string>

using namespace std;

int main()
{
    /* #1 Imperfect solution for two users ages
    int age1;
    int age2;
    cout << "Enter user 1's age: " << endl;
    cin >> age1;
    cout << "Enter user 2's age: " << endl;
    cin >> age2;
    if (age1 > 100 || age2 > 100)
        cout << "Y'all are old!\n";
    else if (age1 > age2)
        cout << "User 1 is old!\n";
    else
        cout << "User 2 is old!\n";
    */

    /* #2 Implement number password with 2 sol'ns, 1 if check
    int pword;
    cout << "Enter the numerical password: \n";
    cin >> pword;
    if (pword == 12345 || pword == 54321)
        {
            cout << "Access Granted!";
        }
    else
        {
            cout << "Access Denied!";
        }
    */

    /* #3 Small calculator with 4 arithmetic ops & 2 args
    char op;
    float arg1, arg2, soln;
    cout << "Enter the operation +, -, * or /: ";
    cin >> op;
    cout << "Enter argument 1: ";
    cin >> arg1;
    cout << "Enter argument 2: ";
    cin >> arg2;
    if (op == '+')
        soln = arg1 + arg2;
    else if (op == '-')
        soln = arg1 - arg2;
    else if (op == '*')
        soln = arg1 * arg2;
    else if (op == '/')
        soln = arg1 / arg2;
    else
        cout << "Please enter a valid operation next time.";
    cout << soln;
    */

    // #4 Expand password program to reprompt for entry
}
