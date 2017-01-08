#include <iostream>

using namespace std;

struct node
{
	int key_value;
	node *p_left;
	node *p_right;
};

node* insert (node* p_tree, int key)
{
	//base: we have reached an empty tree and need to insert our new node here
	if (p_tree == NULL)
	{
		node* p_new_tree = new node;
		p_new_tree->p_left = NULL;
		p_new_tree->p_right = NULL;
		p_new_tree->key_value = key;
		return p_new_tree;
	}
	//decide whether to insert into left subtree or right subtree depending on key
	if (key < p_tree->key_value)
	{
		p_tree->p_left = insert(p_tree->p_left,key);
	}
	else
	{
		p_tree->p_right = insert(p_tree->p_right,key);
	}
	return p_tree;
	
}

node *search (node* p_tree, int key)
{
	//if we reach the empty tree, clearly it's not here!
	if (p_tree == NULL)
		return NULL;
	//if we find the key, we're done!
	else if (key ==  p_tree->key_value)
		return p_tree;
	//otherwise, try looking in either left or right sub-tree
	else if (key < p_tree->key_value)
		return search(p_tree->p_left, key);
	else
		return search(p_tree->p_right, key);
}

void destroyTree (node* p_tree)
{
	if (p_tree != NULL)
	{
		destroyTree(p_tree->p_left);
		destroyTree(p_tree->p_right);
		delete p_tree;
	}
}

node* find_max(node* p_tree)
{
	if (p_tree == NULL)
		return NULL;
	if (p_tree->p_right == NULL)
		return p_tree;
	return find_max(p_tree->p_right);
}

node* remove_max_node (node* p_tree, node* p_max_node)
{
	if (p_tree == NULL)
		return NULL;
	if (p_tree == p_max_node)
		return p_max_node->p_left;
	
	p_tree->p_right = remove_max_node(p_tree->p_right, p_max_node);
	return p_tree;
}

node *remove (node* p_tree, int key)
{
	//if we have an empty tree, we're done!
	if (p_tree == NULL)
		return NULL;
	// if we find the value, remove it!
	if (p_tree->key_value == key)
	{
		if (p_tree->p_left == NULL)
		{
			node* p_right_subtree = p_tree->p_right;
			delete p_tree;
			return p_right_subtree;
		}
		
		if (p_tree->p_right == NULL)
		{
			node* p_left_subtree = p_tree->p_left;
			delete p_tree;
			return p_left_subtree;
		}
		
		node* p_max_mode = find_max(p_tree->p_left);
		p_max_node->p_left = remove_max_node(p_tree->p_left, p_max_node);
		p_max_node->p_right = p_tree->p_right;
		delete p_tree;
		return p_max_node;
	}
	//if key is in the left sub-tree, remove that value
	else if (key < p_tree->key_value)
		p_tree->left = remove(p_tree->left,key);
	//if key is in the right sub-tree, remove that value
	else
		p_tree->right = remove(p_tree->right,key);
	return p_tree;
}

int main()
{
	cout << "Binary Trees" << endl;
}
