setwd("C:/Users/acer/Documents/In¿ynieria Biomedyczna S IV")
inbo =read.csv("dane_inbody.csv")
antro = read.csv("dane_antropo_13.csv")

names(antro)
antro = antro[,-2]
summary(antro)
antro[,1]=factor(antro[,1])
antro[antro==0]=NA
antro[antro==""]=NA

# wysokoœæ h 17,2 na 172
antro$Wysokosc[antro$Wysokosc == 17.2] = 172
# wysokoœæ siedzeniowa 175,5 75,5
antro$WysokoscSiedzeniowa[antro$WysokoscSiedzeniowa== 175.5] = 75.5
# obwód uda '10'

# szer barkóW '12'
# szer bioder 13 
# fa³d pod ³opatk¹ OUT 17 
# ciœnienie sk, rozk, têtno 19-21

kolzwo= c(10,12,13,17,19:21)
pairs(~., data=antro[,kolzwo])

# 01.04.2022
# usuwanie odstaj¹cych
# a) 
gorna_granica = 3*quantile(antro$TetnoKrwi,0.99, na.rm = T)
dolna_granica = 0.3*quantile(antro$TetnoKrwi,0.01,na.rm=T)
# antro$TetnoKrwi[antro$TetnoKrwi>gg]=gg
# antro$TetnoKrwi[antro$TetnoKrwi<gd]=gd

b=boxplot(antro$TetnoKrwi, range=zakres)
a = 0.06
zakres=qnorm(1-a/2)
# 5% zakres 1.96
# 2% zakres 2.33
# 6% zakres 1.88

# wektor kolzwo to wektor odstaj¹cych

for (i in kolzwo)
{
  ods = boxplot(antro[,i], range=zakres, plot=F)$out
  antro[is.element(antro[,i], ods),i]=NA
}

# inbo

inbo=inbo[,-c(2,3)]

#write.table(antro,"antropo_clear.csv", sep=",", dec=".", na="", row.names = F )

