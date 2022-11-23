Pakeisti Repositories, kad supportintu Add/Get/Delete.

Kuo daugiau naudoti AutoData ir pakeisti tik tai ko reikia testui. Testas turetu buti su kuo maziau pakeitimu - maziau sansu sugriuti.

Norint autodate naudoti tik ant tam tikru parametru:

[Theory]
[InlineAutoData(1)]
public void Test(int i, MovieSession session, Auditorium auditorium)
{}

Clean Architecture, Microsoft DDD, Classic (UI -> Business Logic -> Data Logic)
