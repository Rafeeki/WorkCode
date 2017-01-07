#include <iostream>
#include <string>

using namespace std;

int main()
{
    /* Input Example
    int thisisanumber;

    cout << "Please enter a number: ";
    //cin.ignore() //Reads and discards a character from user
    //cin.get() //Waits for input from user before proceeding
    cin >> thisisanumber;
    cout << "You entered: " << thisisanumber << "\n";
    */

    /* Mathematical Operators
    int x, a; //Creates variables x & a of type int
    x = 5; //assigns 5 to x
    //x == 5; checks to see if x equals 5, returns True
    a = x * 6; //a equals 30
    a = a + 5; //a equals original value of 30 + 5
    x++; //increment x by 1
    x--; //decrement x by 1
    x += 5; //increment x by 5
    x -= 5; //subtract x by 5
    x *= 5; //multiply x by 5
    x /= 5; //divide x by 5
    //cout << "x = " << x << " and a = " << a;
    //cout << x++; //returns original value of x, no increment
    cout << ++x; //returns incremented value of x
    */

    /* Calculator
    int arg1;
    int arg2;
    cout << "Enter first argument: ";
    cin >> arg1;
    cout << "Enter second argument: ";
    cin >> arg2;
    cout << arg1 << " * " << arg2 << " = " << arg1 * arg2 << endl;
    cout << arg1 << " + " << arg2 << " = " << arg1 + arg2 << endl;
    cout << arg1 << " / " << arg2 << " = " << arg1 / arg2 << endl;
    cout << arg1 << " - " << arg2 << " = " << arg1 - arg2 << endl;
    */

    /* Strings - must #include <string> header*/
    /*string user_name, last_name;
    cout << "Please enter your first name: ";
    cin >> user_name;
    cout << "Please enter your last name: ";
    cin >> last_name;
    string user_full_name = user_name + " " + last_name;
    cout << "Your name is: " << user_full_name << "\n";*/

    /* Create variable from input ending at ','*/
    string my_string;
    getline(cin, my_string, ',');
    cout << my_string;

}
