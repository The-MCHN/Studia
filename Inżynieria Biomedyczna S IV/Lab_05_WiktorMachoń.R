setwd("C:/Users/acer/Documents/In¿ynieria Biomedyczna S IV")
inbo =read.csv("dane_inbody.csv")

# usunieto id bad, dat i kolumy 122:222
inbo=inbo[,-c(2,3, 122:222)]

while("inbo" %in% search()){
  detach(inbo)
}

attach(inbo)


summary(inbo)

hist(Age)
library(wesanderson)
paleta=wes_palette(name="Darjeeling2")
hist(Age, col=paleta, main="esufeku")
plot(Age, col="palegreen1", pch=17)

dw=c(3,3.2,4,2,5)
barplot(dw)
barplot(dw[order(dw)])

png("wykres_kolumnowy.png", width = 1000, height = 600)
barplot(dw, col=paleta, border = NA, main="tytulik", 
        xlab="iksiczki", ylab="igreki moje", 
        names=c("RIB", "RMS", "RCh", "RAU", "RG"))
dev.off()

za.stary=which(Age>21) #34. wiersz
inbo$id[za.stary] #id = 142
inbo[id==142, 1:6]

inbo$DateOfBirth[34]="16.11.1999"
inbo$Age[34]=15.8

# grepl("Impedance", names(inbo), fixed=T) #wektor boole
imp=grep("Impedance", names(inbo), fixed=T) # numery kolumn
inbo=inbo[,-imp]

kol_moga_byc_0 = c(75:77)
kolumny_z_0_do_usuniecia = setdiff(c(1:ncol(inbo)), kol_moga_byc_0)

inbo[,kolumny_z_0_do_usuniecia][inbo[,kolumny_z_0_do_usuniecia]<=0]=NA

inbo[,4]=factor(inbo[,4])
inbo[,82]=factor(inbo[,82])


write.table(inbo, "dane_inbody_clear.csv", sep=",", dec=".", na="", row.names = F)














