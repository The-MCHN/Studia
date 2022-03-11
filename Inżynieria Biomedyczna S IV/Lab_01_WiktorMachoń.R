a=3+6
b<-4+7
2+1->d
a->d
# hash robi komentarz
print(b)
print("koniec obliczeñ")

r=1:5
r

# c() konstruktor dla wektorów
s= c(1:5)
s[2]
s[2]=-2

if(r==s){
  print("równe")
}

# r==s wypluwa TRUE/FALSE element po elemencie
r==s

# jak sobie z tym radziæ?

if(all(r==s)){
  print("równe")
}else 
{
  print("inne")
}

x=r*2
x=r+r
y=r^3

# wypisze zmienne
ls()
# usuwa zmienne
remove(a)
rm(b)
ls()


# usuwanie wszystkich zmiennych z przestrzeni roboczej
rm(list = ls())

# wyrzuca error
library(car) 
# wyrzuca warning
require(car) 

#install.packages("car", dependencies = T)

suppressWarnings(suppressMessages(library(car)))
























