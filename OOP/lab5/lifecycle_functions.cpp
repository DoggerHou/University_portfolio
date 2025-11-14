#include <iostream>

using namespace std;

class Base {
public:
    Base() {
        cout << "Base()\n";
    }
    Base(Base* object) {        //конструктор принимающий указатель
        cout << "Base(* object)\n";
    }
    Base(Base& object) {        //конструктор принимающий адресс
        cout << "Base(& object)\n";
    }
    virtual ~Base() {
        cout << "~Base()\n";
    }
    void Crush() { cout << "WTF, it's working......\n"; }
};

class Desk :public Base {
public:
    Desk() {
        cout << "Desk()\n";
    }
    Desk(Desk* object) {
        cout << "Desk(* object)\n";
    }
    Desk(Desk& object) {
        cout << "Desk(& object)\n";
    }
    ~Desk() {
        cout << "~Desk()\n";
    }
};

void func1(Base object) { cout << "func1(Base object)\n"; }
void func2(Base* object) { cout << "func2(Base* object)\n"; }
void func3(Base& object) { cout << "func3(Base& object)\n"; }

//Динамические объекты внутри функций
Base Output_1() { 
    cout << "Base Output_1()\n";
    Base* object = new Base();  
    return *object;
}
Base* Output_2() {
    cout << "Base* Output_2()\n";
    Base* object = new Base();
    return object;
}
Base& Output_3() {
    cout << "Base& Output_3()\n";
    Base* object = new Base();
    return *object;
}
//Статические объекты внутри функций
Base Output_4() {
    cout << "Base Output_4()\n";
    Base object;
    return object;
}
Base* Output_5() {
    cout << "Base* Output_5()\n";
    Base object;
    return &object;
}
Base& Output_6() {
    cout << "Base& Output_6()\n";
    Base object;
    return object;
}

int main()
{
    setlocale(LC_ALL, "RUS");




    cout << "-----------------------Смотрим на передачу в функцию для Base:\n";
    Base pb1;
    cout << "-----------------------\n";
    func1(pb1);     //в данном случае создается копия b1 и передается в func1
    cout << "-----------------------\n";
    func2(&pb1);
    cout << "-----------------------\n";
    func3(pb1);




    cout << "\n\n\n-----------------------Смотрим на передачу в функцию для Desk:\n";
    Desk pd1;;
    cout << "-----------------------\n";
    func1(pd1);
    cout << "-----------------------\n";
    func2(&pd1);
    cout << "-----------------------\n";
    func3(pd1);




    cout << "\n\n\n------------------------Смотрим на возващение из функции для Base:\n";
    Base baza1;
    baza1 = Output_1();//Видим, что динамический объект из func1  НЕ уничтожился\n";
    cout << "------------------------\n";
    Base baza2 = Output_2();//никакого копирования и прочего прочего, все отлично
    cout << "-----------------------\n";
    Base &baza3 = Output_3();//в данном случае проблема в том, что baza3 - это ссылка, и ее удаление не удалит
                             //сам объект
    delete &baza3;
    cout << "------------------------Возвращаем статические объекты:\n";
    Base baza4;
    baza4 = Output_4();//Видим огромное количество созданий и удалений объектов
    cout << "------------------------\n";
    Base* baza5 = Output_5();//Тут мы обратимся к несуществующей памяти(в процессе копирования), следовательно, краш
    baza5->Crush();
    //delete baza5;//именно тут мы попытаемся удалить объект, которого нет
    cout << "-----------------------\n";
    Base &baza6 = Output_6();//объект не скопируется
    //delete& baza6;//опять таки, пытаемся копировать уже удаленный объект




    cout << "\n\n\n-----------------------Ниже смотрим на возващение из функции для Desk\n";
    Base* desk1 = new Desk();
    *desk1 = Output_1();   //Скопировал, но не удалил динамический объект
    delete desk1;
    cout << "-----------------------\n";
    Base* desk2 = new Desk();
    desk2 = Output_2();//Скопировал, но динамический объект из функции НЕ удалился
    delete desk2;
    cout << "-----------------------\n";
    Base* desk3 = new Desk();
    *desk3 = Output_3();//передали Адресс созданного в функции объекта, но старый так и остался в стеке;
    delete desk3;
    cout << "-----------------------Возвращаем статические объекты:\n";
    Base* desk4 = new Desk();
    *desk4 = Output_4();//Объекты удалились и передались, оставив за собой след из кучи созданий/удалений
    delete desk4;
    cout << "-----------------------\n";
    Base* desk5 = new Desk();
    desk5 = Output_5();//Объект в функции удалился до копирования
    //delete desk5; 
    cout << "-----------------------\n";
    Base* desk6 = new Desk();
    *desk6 = Output_6();//Объект в функции удалился до копирования
    delete desk6;//удалить можем, ибо работает как бы "присваивание по ссылке"
    cout << "-----------------------Ниже удалятся статические объекты:baza1,baza2,baza4, pd1, pb1\n";
}