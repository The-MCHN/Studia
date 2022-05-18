setwd("C:/Users/acer/Documents/In¿ynieria Biomedyczna S IV")
d= read.csv("wynikowy_clear.csv", header=TRUE, sep=";", dec=",")

Plec=DataUrodzenia=rep(NA, times=nrow(d))

for (wiersz in 1:nrow(d))
{
  for (kol in 182:190)
  {
    if(!is.na(d[wiersz,kol])&d[wiersz,kol]!="")
    {
      DataUrodzenia[wiersz]=d[wiersz,kol]
    }
  }
  for (kol in 200:208)
  {
    if(!is.na(d[wiersz,kol])&d[wiersz,kol]!="")
    {
      Plec[wiersz]=d[wiersz,kol]
    }
  }
}

ID = d$ID

do.usuniecia = c(2:10, 182:190, 200:217)

d=d[,-do.usuniecia]

d=cbind(ID, DataUrodzenia, Plec,d[,c(2:ncol(d))])

faktorowe=c(1,3, 868:876)

for (i in faktorowe)
{
  d[,i]=factor(d[,i])
}

write.table(d, "wynikowy_superclear.csv", sep=";", dec=",", na="", row.names = F)

# feature selection ridge, lasso, jmi, step-wise forward

d_stack = data.frame(ID=rep(d$ID, each=9))
d_stack=cbind(d_stack, DataUrodzenia=rep(d$DataUrodzenia, each=9))
d_stack=cbind(d_stack, DataUrodzenia=rep(d$Plec, each=9))

nazwy=names(d)[seq(from=4, by=9, to=ncol(d))]

for (i in 1:length(nazwy))
{
  nazwy[i]=strsplit(nazwy[i], split=".1")[[1]]
}


m=matrix(NA, nrow=nrow(d_stack), ncol=length(nazwy))
colnames(m)=nazwy
licznik = 1

for(i in seq(from=4, by=9, to=ncol(d)))
{
  for (pom in 1:9)
  {
    m[seq(from=pom, by=9, to=nrow(m)),licznik]=d[,(i+pom-1)]
  }
  licznik = licznik + 1
}

d_stack=cbind(d_stack, as.data.frame(m))

summary(d_stack)
numeryczne=c(4:99,101:123)
for (i in numeryczne)
{
  d_stack[,i]=as.numeric(d_stack[,i])
}

write.csv(d_stack, "dane_stack.csv", sep=";", dec=",", na="", row.names=F)
