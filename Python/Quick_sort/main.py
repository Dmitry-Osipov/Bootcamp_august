# Работа алгоритма:
# худшее время - O(n^2)
# среднее время - O(n * log(n))
# лучшее время - O(n)


def quick_sort(numbers_list):
    if len(numbers_list) <= 1:
        return numbers_list
    else:
        pivot = numbers_list[0]
        left_list = [x for x in numbers_list[1:] if x < pivot]
        right_list = [x for x in numbers_list[1:] if x >= pivot]
        return quick_sort(left_list) + [pivot] + quick_sort(right_list)
    
my_numbers = [1, 6, 0, -3, 2, 1, 9, 5, -6]
sorted_my_numbers = quick_sort(my_numbers)
print(sorted_my_numbers)
