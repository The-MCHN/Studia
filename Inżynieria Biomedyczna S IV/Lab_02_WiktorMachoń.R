# In¿ynieria Biomedyczna 
# 18.03.2022
# Wiktor Machoñ

r = 1:5
x = r*2

#######

wektor = c(1,2,5,r,x)
wektor = c(wektor,r,0:-2,wektor)
wektor

rep(r,time=2)
rep(r,time=2)

length(wektor)
wektor5 = which(wektor>5)
wektor5

which.min(wektor5)
which.max(wektor)

wektor[wektor>5] = "du¿e"
# wszystko siê zmienia na stringi


seq(from=2,to=7,length.out=3) #wybierz 2 z 3
# to - gdzie koniec
# by = jaki kork
# length.out - ile elementów ma mieææ wynik

# sklejanie napisów
paste("OK", "Gooogle")
nap = "mamy"
paste("Zadzwoñ", "do", nap, sep="/")


# MACIERZE

m1 = matrix(1:9, nrow=3, )
m2 = matrix(1:9, nrow=3, byrow = T)

m2[2,1]
m2[1,]
m2[c(1,3),]
m2[,1:2]
m2[,1]

ncol(m2)
nrow(m2)
dim(m2)
which(m2>5, arr.ind = T)

# Listy
lista1 = list(pierwszy = c(1,3,5), second = m2, skakanka = "Hello!")
lista1
lista1$skakanka
lista1$second[3,1]
lista1[[2]][3,1]


lista2 = list(pie = m1[,c(1,3)], chmurka = lista1)
lista2[[2]][[2]][1,2]

lista2[[2]][[3]]

dimnames(m2) = list(wiersze= c("w1","w2","w3"),
                    jablka = paste("kol",1:3, sep = ""))

colnames(m2) = c("kseufhdsk", 3, 5)


######
a = 4.3242132132131232131
round(a)
round(a,2)
signif(a,2)
floor(a)
ceiling(a)

trunc(a)
trunc(-2.7)

a = c(2,34,2,3)


seq(a)
# seq() jest fancy

# 1:length te¿ dzia³a, ale jest wieœniacki

for(iter in 1:length(a))
{
  print(iter)
}

# factor
cukrzyca = c(1,0,0,1,1,0,1)
mean(cukrzyca)
summary(cukrzyca)

cukrzyca = factor(c(1,0,0,1,1,0,1), levels = c(2, 0, 1), ordered=T)
cukrzyca
summary(cukrzyca)


getwd()
setwd()












