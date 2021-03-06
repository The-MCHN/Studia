# Tworzenie dataframe
dane = data.frame(
  id = c(1:5),
  name = c("Robert", "Peter", "Arkadiusz",
           "Maciej", "Grzegorz"),
  cash = c(6300, 2500.7, 10000, 100000, 8550.42),
  currency = c("$", "PLN", "R$", "€", "RUB")
)
print(dane)
# Wyświetlenie podsumowania
print(summary(dane))

# Wyświetlenie konkretnych kolumn
print(data.frame(dane$name, dane$cash))

# Dodanie kolumny
dane$dept = c("IT", "HR", "IT", "Cloud", "SPY")

nowe.dane = data.frame(
  id = c(6:8),
  name = c("Rajesh", "Singha", "Ahmed"),
  cash = c(2000, 2500.7, 1000),
  currency = c("R"),
  dept = c("Support")
)

#połączenie dwóch dataframe
fin.dane = rbind(dane, nowe.dane)
print(fin.dane)

#wyświetlenie konkrentej kolumny
wages = fin.dane[,3]


bobry = beaver1


#ifelse()
#summary()
#head()
#subset(df, cond)
