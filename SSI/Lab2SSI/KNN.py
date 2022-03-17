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

        # sorting
        KNN.quickSort(distances, x, 0, len(distances) - 1)

        # voting
        for i in range(0, k):
            classes[x.iloc[i].variety] += 1

        # print(max(classes, key=classes.get))
        return max(classes, key=classes.get)

    @staticmethod
    def partition(arr, org_arr, low, high):
        i = low - 1
        pivot = arr[high]

        for j in range(low, high):

            if arr[j] <= pivot:
                i = i + 1
                arr[i], arr[j] = arr[j], arr[i]
                org_arr.iloc[i], org_arr.iloc[j] = org_arr.iloc[j], org_arr.iloc[i]

        arr[i + 1], arr[high] = arr[high], arr[i + 1]
        org_arr.iloc[i + 1], org_arr.iloc[high] = org_arr.iloc[high], org_arr.iloc[i + 1]
        return i + 1

    @staticmethod
    def quickSort(arr, org_arr, low, high):
        if len(arr) == 1:
            return arr
        if low < high:
            pi = KNN.partition(arr, org_arr, low, high)

            KNN.quickSort(arr, org_arr, low, pi - 1)
            KNN.quickSort(arr, org_arr, pi + 1, high)


iris1 = ProcessingData.shuffle(iris)
iris1 = ProcessingData.normalize(iris1)
irisTrain, irisTest = ProcessingData.splitSet(iris1, 0.7)

corrected = 0

for e in range(len(irisTest)):
    if KNN.clustering(irisTest.iloc[e], irisTrain, 3, 2) == irisTest.iloc[e].variety:
        corrected += 1

accuracy = corrected / len(irisTest) * 100
print(f"Accuracy: {accuracy:.2f}%")
