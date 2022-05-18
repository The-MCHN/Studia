library(tidyverse)

setwd("C:/Users/acer/Documents/In¿ynieria Biomedyczna S IV")
a = read.csv("antropo_clear.csv", sep=",", dec=",", stringsAsFactors = FALSE)
i = read.csv("dane_inbody_clear.csv", sep=",", dec=",", stringsAsFactors = FALSE)

id = sort(union(a$id, i$id))

lk_a = ncol(a)-1
lk_i = ncol(i)-1

lw = length(id)
lk = lk_a*9 + lk_i*9 +1



m=matrix(NA, nrow=lw, ncol=lk, dimnames=list(ID=id,
                                             Zmienne=c("ID",paste(rep(names(a)[-1],each=9),rep(1:9,times=lk_a)),
                                                       paste(rep(names(i)[-1],each=9),rep(1:9,times=lk_i)))))


m=as.data.frame(m)

for(j in 1:nrow(a))
  {
  wiersz = which(id==a[j,1])
  data=a[j,2]
  if(str_detect(data, "-09-")|str_detect(data,"-10-")|str_detect(data, ".09.")|str_detect(data,".10."))
  {
    pomiarkandydaci = c(1,3,5,7,9)
  }
  else
  {
    pomiarkandydaci = c(2,4,6,8)
  }
  if (str_detect(data,"2019"))
  {
    pomiar = intersect(pomiarkandydaci, c(8,9))
  }
  if (str_detect(data,"2018"))
  {
    pomiar = intersect(pomiarkandydaci, c(6,7))
  }
  if (str_detect(data,"2017"))
  {
    pomiar = intersect(pomiarkandydaci, c(4,5))
  }
  if (str_detect(data,"2016"))
  {
    pomiar = intersect(pomiarkandydaci, c(2,3))
  }
  if (str_detect(data,"2015"))
  {
    pomiar = 1
  }
  
  for (k in 1:lk_a)
  {
    m[wiersz,(k-1)*9 + pomiar +1]=a[j,k+1] # j k pomiar lk_a lk_i 9
  }
  # dla k=1
  # a[j,2] przypisujemy do 2-10 (w zale¿noœci od pomiaru)
  # jeœli pomiar = 3 
  # a[j,2] to przypisalibyœmy do 4
  # jeœli pomiar = 4 
  # a[j,2] to przypisalibyœmy do 5
  # jeœli pomiar = 9 
  # a[j,2] to przypisalibyœmy do 10
                                                       
}

for(j in 1:nrow(i))
{
  wiersz = which(id==i[j,1])
  data=strsplit(i[j,5], split=".")[[1]][1]
  
  if(str_detect(data, "-09-")|str_detect(data,"-10-")|str_detect(data, ".09.")|str_detect(data,".10."))
  {
    pomiarkandydaci = c(1,3,5,7,9)
  }
  else
  {
    pomiarkandydaci = c(2,4,6,8)
  }
  if (str_detect(data,"2019"))
  {
    pomiar = intersect(pomiarkandydaci, c(8,9))
  }
  if (str_detect(data,"2018"))
  {
    pomiar = intersect(pomiarkandydaci, c(6,7))
  }
  if (str_detect(data,"2017"))
  {
    pomiar = intersect(pomiarkandydaci, c(4,5))
  }
  if (str_detect(data,"2016"))
  {
    pomiar = intersect(pomiarkandydaci, c(2,3))
  }
  if (str_detect(data,"2015"))
  {
    pomiar = 1
  }
  
  for (k in 1:lk_i)
  {
    m[wiersz,(k-1+lk_a)*9 + pomiar +1]=i[j,k+1]
  }
  
}

m[,1]=row.names(m)
write.table(m, "wynikowy_clear.csv", sep=";", dec=",", na="", row.names = F)
