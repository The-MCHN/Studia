import random

import numpy as np
import random as rd
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt

iris = pd.read_csv('iris.csv')


class ProcessingData:
    @staticmethod
    def shuffle(db):
        print("Shuffle")
        # db.iloc[1]=db.iloc[3]
        for i in range(len(db) - 1, 0, -1):
            k = random.randint(0, i)
            db.iloc[i], db.iloc[k] = db.iloc[k], db.iloc[i]
        return db

    @staticmethod
    def splitSet(x, k):
        xTrain = x[:int(len(x) * k)]
        xValidation = x[int(len(x) * k):]
        return xTrain, xValidation

    @staticmethod
    def normalize(x):
        # (x - min) / (max - min)
        values = x.select_dtypes(exclude='object')
        columnNames = values.columns.tolist()
        for column in columnNames:
            data = x.loc[:, column]
            max1 = max(data)
            min1 = min(data)
            for row in range(0, len(x) - 1):
                val = (x.at[row, column] - min1) / (max1 - min1)
                x.at[row, column] = val
        return x


# print(iris.head())

print(iris.describe())


# print(iris.info())

# sns.pairplot(iris, hue='variety', markers='+')
# sns.violinplot(y='variety', x='sepal.length', data=iris, inner='quartile')
# plt.show()


# iris1 = ProcessingData.shuffle(iris)
iris1 = ProcessingData.normalize(iris)
print(iris1.head())
