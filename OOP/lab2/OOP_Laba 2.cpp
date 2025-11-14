#include <iostream>

using namespace std;

class Point {
protected:
	int x;
	int y;
public:
	Point() {						// конструктор по умолчанию
		x = 0;
		y = 0;
		cout << "Point();" << endl;
	}
	Point(int x, int y) {			// конструктор с параметрами
		this->x = x;
		this->y = y;
		cout << "Point(int x, int y);" << endl;
	}
	Point(const Point& t) {			// конструктор копирования 
		x = t.x;
		y = t.y;
		cout << "Point(const Point &t);" << endl;
	}
	~Point() {						//Деструктор
		cout << "~Point()" << endl;	
		cout << "x = " << x << "\ny = " << y << endl;
		
	}
	void Print() {					// метод отрисовки
		cout << "Point x = " << x << "\nPoint y = " << y<<endl;
	}
	void Set( int x, int y) {		// метод Set
		this->x = x;
		this->y = y;
	}
	void After_Definition();

	Point(const Point* pa):x((*pa).x), y((*pa).y) { //конструктор !=копирования, принимающий
		cout << "Point(const Point* pa);" << endl;	//указатель
	}	
};														

void Point::After_Definition() {	//Реализация метода вне класса
	cout << "\nIt's working:\nOutput x:" << x <<"\nOutput y:"<< y << endl<<endl;
}

class Rectangle {
private:
	int length;
	int width;
	int Check() {
		return 1337;
	}
protected:
	string name;
public:
	int height;
	
	Rectangle(){
		length = 5;
		width = 5;
		height = 10;
		cout << "length =" << length << "   width = " << width << "   height = " << height << endl;
	}
	void Print() {
			cout << "length =" << length << "   width = " << width << "   height = " << height << endl;
		}
};

class Point3D :public Point {
protected:
	int z;
public:
	Point3D(): Point() {						// конструктор по умолчанию(с выозовом от Point)
		z = 0;
		cout << "Point3D();" << endl;
	}
	Point3D(int x, int y, int z) {			// конструктор с параметрами(переопределенный)
		this->x = x;
		this->y = y;
		this->z = z;
		cout << "Point3D(int x, int y, int z);" << endl;
	}
	Point3D(const Point3D& t): Point(t) {			// конструктор копирования 
		z = t.z;
		cout << "Point3D(int x, int y, int z);" << endl;
	}
	~Point3D() {						//Деструктор
		cout << "~Point3D()" << endl;
		cout << "x = " << x << "\ny = " << y << "\nz = " << z << endl;
		
	}
	void Check() {}
};

class Section {
public:
	Point pbeg;
	Point pend;
	Section() {
		//pbeg = new Point(0, 0);
		//pend = new Point(0, 0);
		cout << "Section()\n";
	}
	Section(int x1, int y1, int x2, int y2) : pbeg(x1, y1), pend(x2, y2) {
		//pbeg = new Point(x1, y1);
		//pend = new Point(x2, y2);
		cout << "Section(int x1, int y1, int x2, int y2)\n";
	}
	Section(const Section &s) : pbeg(s.pbeg), pend(s.pend) {
		//pbeg = new Point(*s.pbeg);
		//pend = new Point(*s.pend);
		cout << "Section(const Section &s)\n";
	}
	~Section() {
		//delete pbeg;
		//delete pend;
		cout << "~Section\n";
	}

};




int main()
{
	{						//статические объекты
		cout << "Static objects:\n\n\n";
		Point a1;
		Point a2(25, 75);
		Point a3(a2);
		a1.Set(1, 2);
		a1.After_Definition();
	}
	cout << "\nDynamic objects:\n\n\n";
	{						//Динамические объекты
		Point *p1 = new Point();
		p1->Set(1, 1);
		p1->Print();
		Point *p2 = new Point(228, 322);
		Point *p3 = new Point(*p2);
		Point *p4 = new Point(p3);
		p4->Print();
		cout << "Deleting Dynamic objects:\n";
		delete p1;
		delete p2;
		delete p3;
		delete p4;
	}

	{					//Проверка атрибутов
		cout << "\nChekink attributes:\n\n\n";
		Rectangle rec1;
		rec1.height = 25;
		rec1.Print();
	}

	{					//Наследники и прочее прочее
		cout << "\nReal things Duuuude:\n\n\n";
		Point3D* p1 = new Point3D;
		Point* p2 = new Point3D(1, 2, 3);
		delete p1;
		delete p2;

		cout << "Cheking\n";
		Point p3 = Point3D(5, 6, 7);
		p3.Set(2, 5);
	}

	{				//Композиция
		cout << endl << endl << endl;
		Section sec;
	}
	

}
