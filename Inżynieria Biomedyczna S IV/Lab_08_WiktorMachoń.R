setwd("C:/Users/acer/Documents/In¿ynieria Biomedyczna S IV")
d_stack=read.csv("dane_stack.csv", header = TRUE, sep=",", dec=".", stringsAsFactors = FALSE)

library(corrplot)
library(PerformanceAnalytics)

do.kor.a=c(4:6) #wys. siedzeniowa, obwod szyi
do.kor.i=c(27,36,75,79) #TBW, protein, FFMPofR/L

M=cor(x=d_stack[,do.kor.i],y=d_stack[,do.kor.a], use="pairwise.complete.obs",method="pearson")
kolorki=colorRampPalette(c("royalblue4", "white", "red"))(200)
corrplot(M, col=kolorki)
corrplot(M, method="number")
chart.Correlation(d_stack[,c(do.kor.a, do.kor.i)], histogram=T, pch=21, method="spearman")

library(dummies)
dclas=d_stack[,3:24]
dclas=dummy.data.frame(dclas)
dclas=dclas[,-1]
names(dclas)[1]="Plec"

dreg=cbind(dclas,d_stack[,27])
names(dreg)[23]="TBW"

odpowiednie.nawodnienie=rep(NA,nrow(d_stack))
odpowiednie.nawodnienie[(d_stack[,27]<d_stack[,28])|(d_stack[,27]>d_stack[,28])]=0
odpowiednie.nawodnienie[(d_stack[,27]>d_stack[,28])&(d_stack[,27]<d_stack[,28])]=1

dclas=cbind(dclas, odpowiednie.nawodnienie)
write.table(dclas,"dane_clas.csv",sep=";",dec=",", na="",row.names = F)
write.table(dreg,"dane_reg.csv",sep=";",dec=",", na="",row.names = F)


ocena<<-function(macierz.bledow, nazwa.klasyfikatora="brak nazwy"){
  #macierz postaci
  #| TP  FP|
  #| FN  TN|
  
  tp=macierz.bledow[1,1]
  fp=macierz.bledow[1,2]
  fn=macierz.bledow[2,1]
  tn=macierz.bledow[2,2]
  
  acc=(tp+tn)/(tp+tn+fp+fn) #accuracy
  sen=tp/(tp+fn) #sensitivity
  spe=tn/(tn+fp) #specifity
  pre=tp/(tp+fp) #precisioon
  f1=2*pre*sen/(pre+sen) #score
  
  jakosc=c(acc,sen,spe,pre,f1)
  nazwy=c("dokladnosc","czu³oœæ","specyficznoœæ","precyzja","F1")
  kol=c("slategray2", "seashell2","lightpink2","wheat2","cornflowerblue")
  
  while (names(dev.cur()) != "null device") dev.off()
  png(paste(nazwa.klasyfikatora,".png",sep=""), width = 1000, height = 800)
  barplot(jakosc, col=kol, main=nazwa.klasyfikatora, names=nazwy, ylim=c(0,1)) #ylim-skala
  dev.off()
  jakosc.ramka=data.frame(acc,sen,spe,pre,f1)
  return(jakosc.ramka)
  
}

df.on=subset(dclas,!is.na(dclas$odpowiednie.nawodnienie))
library(caTools)
complete.cases(df.on)
df.on=df.on[complete.cases(df.on),]



split=sample.split(df.on$odpowiednie.nawodnienie, SplitRatio = 0.8)
train_set=subset(df.on, split==TRUE)
test_set=subset(df.on, split==FALSE)

trainX=train_set[,-ncol(df.on)]
testX=test_set[,-ncol(df.on)]

trainY=train_set[,ncol(df.on)]
testY=test_set[,ncol(df.on)]

k=5
trainX_s=scale(trainX)
testX_s=scale(testX)

#KNN
library(class)
knn.pred=knn(trainX_s, testX_s, trainY, k=5)

wyn=table(knn.pred, testY)
#wyn.knn=ocena(macierzz.bledow = wyn, nazwa.klasyfikatora="KNN")
wyn.knn=ocena(wyn,"KNN")
wyn.knn

#drzewa decyzyjne
library(rpart)
library(rpart.plot)

classtree=rpart(formula=odpowiednie.nawodnienie~., data=train_set,method="class", control = rpart.control(maxdepth = 3))

rpart.plot(classtree, box.palette = "RdBu", digit=-2)
ssd.pred=predict(classtree,test_set, type="class")
wyn=table(test_set$odpowiednie.nawodnienie, ssd.pred)
wyn.ssd=ocena(wyn, "Simple tree depth 3")
wyn.ssd

###13.05.2022##

###Ensemble method 1 - Bagging


library(randomForest)

bagging = randomForest(formula= odpowiednie.nawodnienie~., data=train_set, mtry=22, method="class")

#mtry - ile zmiennych gdybyœmy podali mtry nizszy ni¿ liczba wszystkich mo¿liwych
# predykatorów to robilibyœmy random forest
# poniewa¿ bierzemy wszystkie mo¿liwe predykatorey to jest to bagiing 
# w bagingu s¹ wszystkie predyktory, ale zmieniaj¹ siê zbiory ucz¹ce
#random forest ma inne zbiory ucz¹ce i ograniczon¹ liczbê predykatorów

#jeœli robimy bagging to nie da siê zrobiæ wykresu drzewa,
# jest poprawa jakoœci klaasyfikacji,
# p³aci siê za to mniejsz¹ mo¿liwoœæ interpretacji

bag_pred = predict(bagging, test_set)
wyn = table(test_set$odpowiednie.nawodnienie, bag_pred)
wyn.bag=ocena(wyn, "Bagging")

# Ensemble method 2 Random Forest
randomfor = randomForest(formula=odpowiednie.nawodnienie~., data=train_set, 
                         method="class", ntree=100)

randomfor_pred = predict(randomfor, test_set)
wyn=table(test_set$odpowiednie.nawodnienie,randomfor_pred)
wyn.rf=ocena(wyn, "Random Forest")

# Ensemble method 3 AdaBoost
# w AB drzewa rosn¹ sekwencyjnie
# ka¿de drzewo jest budowane na podstawie informacji
# z wyniów dziaania poprzednio utworzonego drzewa
# po pierwszym zbudowaniu drzewa wyszukuje siê Ÿle sklasyfikowane
# przypadki albo te z du¿ymi rezyduai
# tym przypadkom nadaje siê wiêksz¹ wagê i trenuje ponownie drzewo i tak N-1 razy :)



library(adabag)
adaboost = boosting(odpowiednie.nawodnienie~.,
                    data = train_set, boos=TRUE, mfinal=50)

# mfinal - ile drzew? default 100

ada_pred = predict(adaboost, test_set)
wyn=table(test_set$odpowiednie.nawodnienie, ada_pred$class)
wyn.ada=ocena(wyn, "ADABOOST")
t1 = adaboost$trees[[50]]
plot(t1)
text(t1, pretty=100)

# SVM Support Vector Machine
# SVM jest wra¿liwy na skalê zmiennych - trzeba wykonaæ normalizacjê
# m = 0, sd = 1
library(e1071)
# svm dzia³a dla klasyfikacji i dla regresji\
# wybór pomiêdzy nimi zale¿y tylko od tego,
# czy zmienna bêdzie numeryczna czy faktorowa

# j¹dro liniowe

svmfitL = svm(odpowiednie.nawodnienie~., data = train_set, kernel="linear", scale = TRUE)
svm_lin_pred = predict(svmfitL, test_set)
wyn = table(test_set$odpowiednie.nawodnienie, svm_lin_pred)
wyn.svm.lin=ocena(wyn, "Svm lin")

svmfitL$index
# Hyperparameter tuning
# C- cost

tune.out.lin = tune(svm, odpowiednie.nawodnienie~., data = train_set, kernel="linear",
                    ranges=list(cost=c(0.001, 0.01, 0.1, 1, 10, 100)))

# dostrajanie/tuning jest wykonywany przez 10-fold cross validation
# mo¿na dodaæ parametr cross=

best_mod_line = tune.out.lin$best.model
summary(best_mod_line)

svm_lin_pred_100 = predict(best_mod_line, test_set)
wyn=table(test_set$odpowiednie.nawodnienie, svm_lin_pred_100)
wyn.SVM.lin.100=ocena(wyn, "SVM lin tuned cost 100")

# polymonial kernel


svmfitK = svm(odpowiednie.nawodnienie~., data = train_set, kernel="polymonial", 
              degree = 2)
svm_ply_pred = predict(svmfitK, test_set)
wyn = table(test_set$odpowiednie.nawodnienie, svm_poly_pred)
wyn.svm.poly=ocena(wyn, "Svm poly")




tune.outP = tune(svm, odpowiednie.nawodnienie~., data = train_set, kernel="polynomial",
                 cross=4, 
                    ranges=list(cost=c(0.001, 0.01, 0.1, 1, 10, 100),
                                degree=c(0.5, 1, 2, 3, 5)))


best_modP = tune.outP$best.model
summary(best_modP)

svm_poly_pred_5 = predict(best_modP, test_set)
wyn=table(test_set$odpowiednie.nawodnienie, svm_poly_pred_5)
wyn.SVM.poly.5=ocena(wyn, "SVM poly cost 5")

svmfitR = svm(odpowiednie.nawodnienie~., data=train_set, kernel="radial",
              gamma=1)
svm.rad.pred=predict(svmfitR, test_set)
wyn=table(test_set$odpowiednie.nawodnienie, svm.rad.pred)
wyn.svm.rad=ocena(wyn, "SVM rad")

tune.outR = tune(svm, odpowiednie.nawodnienie~., data=train_set,
                 cross=4, kernel="radial",
                 ranges=list(cost=c(0.001, 0.01, 0.1, 1, 5, 10, 100, 1000),
                             gamma=c(0.01, 0.1, 0.5, 1, 2,3,10,30)))

bestmodR = tune.outR$best.model
summary(bestmodR)
svm.rad.pred.10=predict(bestmodR,test_set)
wyn=table(test_set$odpowiednie.nawodnienie, svm.rad.pred.10)
wyn.svm.rad.10=ocen(wyk, "svm.rad.pred.10")













