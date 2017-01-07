#include <iostream>
#include <string>

using namespace std;

void NamePrompt(string *p_first, string *p_last)
{
    //To output text held by address
    cout << "You are " << *p_first << " " << *p_last << "!\n";

    //To output memory address
    cout << "First location: " << p_first << " & Last location: " << p_last << "!\n";
}

int main()
{
    string first;
    string last;
    cout << "Enter your first name: ";
    cin >> first;
    cout << "Enter your last name: ";
    cin >> last;
    NamePrompt(&first, &last);
}
