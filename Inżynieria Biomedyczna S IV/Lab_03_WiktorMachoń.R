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

