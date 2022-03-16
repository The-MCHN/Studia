import random

import pandas as pd

iris = pd.read_csv('iris.csv')


class ProcessingData:
    @staticmethod
    def shuffle(db):
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
        values = x.select_dtypes(exclude='object')
        columnNames = values.columns.tolist()
        for column in columnNames:
            data = x.loc[:, column]
            max1 = max(data)
            min1 = min(data)
            for row in range(0, len(x)):
                val = (x.at[row, column] - min1) / (max1 - min1)
                x.at[row, column] = val
        return x


class KNN:
    @staticmethod
    def minkowski(v1, v2, m):
        dist = 0
        for e in range(0, len(v1) - 1):
            dist += abs(v1[e] - v2[e]) ** m
        return dist ** (1 / m)

    @staticmethod
    def clustering(sample, x, k, m):
        classes = {'Setosa': 0, 'Versicolor': 0, 'Virginica': 0}

        # distance btwn sample and each x
        distances = []
        for z in range(len(x)):
            distances.append(KNN.minkowski(sample, x.iloc[z], m))

        # sort x by distance
        for i in range(len(distances) - 1):
            for j in range(0, len(distances) - i - 1):
                if distances[j] > distances[j + 1]:
                    distances[j], distances[j + 1] = distances[j + 1], distances[j]
                    x.iloc[j], x.iloc[j+1] = x.iloc[j+1], x.iloc[j]
        # voting
        for i in range(0, k):
            classes[x.iloc[i].variety] += 1

        # return result
        print(max(classes, key=classes.get))
        return max(classes, key=classes.get)


iris1 = ProcessingData.shuffle(iris)
iris1 = ProcessingData.normalize(iris1)
irisTrain, irisTest = ProcessingData.splitSet(iris1, 0.7)

print(len(irisTrain))
print(len(irisTest))
corrected = 0

for e in range(len(irisTest)):
    if KNN.clustering(irisTest.iloc[e], irisTrain, 3, 2) == irisTest.iloc[e].variety:
        corrected += 1

accuracy = corrected / len(irisTest) * 100
print(corrected)
print(f"Accuracy: {accuracy:.2f}%")
