table_of_products = {
    "tomato": {
        "red": 1,
        "green": 0,
        "tasty": 1,
        "juicy": 1,
        "spicy": 0},

    "onion": {
        "red": 0,
        "green": 1,
        "tasty": 0,
        "juicy": 0,
        "spicy": 0},

    "jalapeno": {
        "red": 0,
        "green": 1,
        "tasty": 1,
        "juicy": 1,
        "spicy": 1},

    "pepper": {
        "red": 1,
        "green": 1,
        "tasty": 1,
        "juicy": 1,
        "spicy": 0},

    "apple": {
        "red": 1,
        "green": 0,
        "tasty": 1,
        "juicy": 1,
        "spicy": 0},

}
# client = [0, 0.7, 0.8, 0, 0.9]
client = [1, 0, 1, 1, 0]


class Soft_sets:
    @staticmethod
    def classify(table, sample):
        list_of_values = []
        for features in table.values():
            # print(features)
            itr = 0
            wsk = 0
            for values in features.values():
                # print(values)
                wsk += sample[itr] * values
                itr += 1
            list_of_values.append(wsk)

        # print(list_of_values)
        suggestion = list(table)[list_of_values.index(max(list_of_values))]

        print(suggestion)


Soft_sets.classify(table_of_products, client)
