#include <iostream>
#include <cstddef> //included for NULL

using namespace std;

struct EnemySpaceShip
{
	int x_coordinate;
	int y_coordinate;
	int weapon_power;
	EnemySpaceShip* p_next_enemy;
};

EnemySpaceShip* p_enemies = NULL;

EnemySpaceShip* getNewEnemy()
{
	EnemySpaceShip* p_ship = new EnemySpaceShip;
	p_ship->x_coordinate = 0;
	p_ship->y_coordinate = 0;
	p_ship->weapon_power = 20;
	p_ship->p_next_enemy = p_enemies;
	p_enemies = p_ship
	return p_ship;
};

void upgradeWeapons(EnemySpaceShip* p_ship)
{
	p_ship->weapon_power+=10;
}

int main()
{
	int count = 0;
	EnemySpaceShip* p_enemy = getNewEnemy();
	while (*p_enemy != NULL)
	{
		upgradeWeapons(p_enemy);
		p_enemy = p_enemy->p_next_enemy;
		count++;
	}
	cout << count << " enemies upgraded" << endl;
}
