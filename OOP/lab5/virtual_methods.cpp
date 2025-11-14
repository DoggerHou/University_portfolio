#include <iostream>

using namespace std;

class Animal {
protected:
	int age = 0;
public:
	Animal() {
		cout << "Animal()\n";
	}
	virtual ~Animal() {//виртуальный деструктор
		cout << "~Animal()\n";
	}
	void Method_1() {
		Method_2();
		age *= 10;
		cout << "Animal::Method_1\t" << age << endl;
	}
	virtual void Method_2() {//тут меняем (virtual) на (не virtual)
		age = 10;
		cout << "Aniaml::Method_2\t" << age << endl;
	}

	void sound_1() {
		cout << "Sound of Animal\n";
	}
	virtual void sound_2() {//виртуальный метод, который далее перекрывается
		cout << "Virtual sound of Animal\n";
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
	void Method_2() {
		age = 1;
		cout << "Cat::Method_2\t" << age << endl;
	}
	void sound_1() {
		cout << "Sound_1 of Cat\n";
	}
	void sound_2() override {
		cout << "override Sound_2 of Cat\n";
	}

};



int main()
{
	//Показывает, зачем нужен виртуальный деструктор

	Animal* cat1 = new Cat();
	delete cat1;
	cout << "\n\n\n";


	//Что если метод 2 в Базовом классе virtual/ не virtual

	Animal* cat2 = new Cat();
	cat2->Method_1();
	cout << "\n\n\n";


	//Обращение через указатель на базовый класс/класс наследника( не virtual)

	Animal* cat3 = new Cat();
	cat3->sound_1();
	Cat* cat4 = new Cat();
	cat4->sound_1();
	cout << "\n\n\n";

	//Обращение через указатель на базовый класс/класс наследника( virtual)

	Animal* cat5 = new Cat();
	cat5->sound_2();
	Cat* cat6 = new Cat();
	cat6->sound_2();
}
