#include <iostream>
#include <memory>

using namespace std;

class Animal {
private:
    int age;
    string name;
public:
    Animal() {
        cout << "Animal()\n";
    }
    ~Animal() {
        cout << "~Animal()\n";
    }
};


int main()
{
    setlocale(LC_ALL, "rus");
    {
        cout << "--------------------\n";
        Animal* dog1 = new Animal();
        cout << "При использовании стандартного указателя, при выходе из области видимости dog1 не удалился\n";
    }
    cout << "--------------------\n\n\n\n";




    cout << "--------------------unique_ptr\n";
    {
        unique_ptr <Animal> unique_dog2(new Animal());
    }
    cout << "\nА тут, как мы видим, динамический объект Animal удалился, когда вышел из своей области видимости\n\n";
    {
        auto unique_dog3 = make_unique<Animal>();
    }
    cout << "make_unique позволяет отказаться от использоваия оператора new\n";
    //А это не создаст утечку памяти, если при исп. new было вызвано исключение
        //т.е если new сработал, создал объект, исключение сработало, но delete никто не вызывал
    cout << "--------------------\n\n\n\n";




    cout << "--------------------shared_ptr\n";
    //но unique_ptr не позволяет нескольким объектам работать с собой, для этого есть shared_ptr
    shared_ptr<Animal> shared_ptr1 = std::make_shared<Animal>(); //Создаётся объект
    {
        shared_ptr<Animal> shared_ptr2 = shared_ptr1; 
        //Теперь у объекта два владельца, выраженных в виде shared_ptr и shared_ptr2
    }   //shared_ptr2 выходит из области видимости, 
    cout << "Уничтожение объекта произойдет тогда, когда shared_ptr1 выйдет из области видимости(т.е. ниже:)\n";
}

