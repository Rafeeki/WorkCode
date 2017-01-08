#include <iostream>
#include <vector>
#include <map>
#include <string>

using namespace std;

int main()
{
	/* Vectors
	vector<int> a_vector(10);
	for (int i = 0; i < 10; i++) //constructor for vector a_vector
	{
		a_vector[i] = i;
	}
	
	cout << "Vector Size = " << a_vector.size() << endl;

	for (int j = 0; j < 10; j++)
	{
		cout << "Vector [" << j << "] = " << a_vector[j] << endl;
	}
	*/
	
	// Maps
	string name, email;
	map<string, string> name_to_email;
	
	
	cout << "Enter a name: ";
	cin >> name;
	cout << "Enter an email: ";
	cin >> email;
	name_to_email[name] = email;
	cout << name << "'s email address is: " << name_to_email[name] << endl;
}

