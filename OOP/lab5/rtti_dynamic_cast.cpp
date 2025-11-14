#include <iostream>

using namespace std;

class Animal {
public:
	Animal() {
		cout << "Animal()\n";
	}
	virtual ~Animal() {
		cout << "~Animal()\n";
	}
	virtual void sound() {
		cout << "Animal sound\n";
	}
	virtual string classname() {
		return "Animal";
	}
	virtual bool isA(const string& who) {
		return who == "Animal";
	}
};

class Dog :public Animal {
public:
	Dog() {
		cout << "Dog()\n";
	}
	~Dog() {
		cout << "~Dog()\n";
	}
	void sound() override {
		cout << "Dod sound\n";
	}
	string classname() override {
		return "Dog";
	}
	void Dog_Method() {
		cout << "Dog Method\n";
	}
	virtual bool isA(const string& who) {
		return (who == "Dog") || (Animal::isA(who));
	}
};

class Cat :public Animal {
public:
	Cat() {
		cout << "Cat()\n";
	}
	~Cat() {
		cout << "~Cat()\n";
	}
	void sound() override {
		cout << "Cat sound\n";
	}
	string classname() override {
		return "Cat";
	}
	void Cat_Method() {
		cout << "Cat Method\n";
	}
	virtual bool isA(const string& who) {
		return (who == "Cat") || (Animal::isA(who));
	}
};

class Manul :public Cat {
public:
	Manul() {
		cout << "Manul()\n";
	}
	~Manul() {
		cout << "~Manul()\n";
	}
	void sound() override {
		cout << "Manul sound\n";
	}
	string classname()  {
		return "Manul";
	}
	void Manul_Method() {
		cout << "Manul Method\n";
	}
	virtual bool isA(const string& who) {
		return (who == "Manul") || (Cat::isA(who));
	}
};

int main()
{
	srand(time(NULL));

	//Почему classname плох в использовании
	Animal* cat_or_manul;
	if (rand() % 2 == 0)
		cat_or_manul = new Cat();
	else
		cat_or_manul = new Manul();

	if(cat_or_manul->classname() == "Cat" || cat_or_manul->classname() == "Manul")
		static_cast<Manul*>(cat_or_manul)->Cat_Method();
	//	((Cat*)cat_or_manul)->Cat_Method();		//аналогичен static_cast



	//Использование isA
	if(cat_or_manul->isA("Cat"))
		static_cast<Manul*>(cat_or_manul)->Cat_Method();



	//Почему небезопасное привидение - не безопасно
	cout << "-------------------------------\n";
	Animal* realDog = new Dog();
	if (static_cast<Cat*>(realDog))
		static_cast<Cat*>(realDog)->Cat_Method();
	cout << "-------------------------------\n";



	//Использование dynamic_cast
	Animal* zoo[20];
	for (int i = 0; i < 20; i++) {
		if (rand() % 2 == 0)
			zoo[i] = new Cat();
		else
			zoo[i] = new Dog();
	}
	for (int i = 0; i < 20; i++) {
		if (dynamic_cast<Cat*>(zoo[i]))
			dynamic_cast<Cat*>(zoo[i])->Cat_Method();
		else if (dynamic_cast<Dog*>(zoo[i]))
			dynamic_cast<Dog*>(zoo[i])->Dog_Method();
		else if (dynamic_cast<Manul*>(zoo[i]))
			dynamic_cast<Manul*>(zoo[i])->Manul_Method();
	}
}
