import random
import time
import json

def test_password():
  word_order = ["common", "s", "a", "t", "c", "b", "d", "e", "f", "w", "g", "h", "i", "l", "p", "r", "m", "u", "n", "o", "j", "k", "x", "v", "y", "q", "z"]

  with open('words.txt') as word_holder:
    words_list = json.load(word_holder)[0]

  # Currently trying words starting with this letter in word list
  current_letter = word_order[0]
  # Index of current word withing its letter's section
  current_letter_index = 0

  guesses = 0

  current_guess = 0

  all_guesses = 0

  reps = [0,1]

  status = "ongoing"

  password_length_to_start = 1

  password_length = password_length_to_start

  password_length_to_generate = 3

  target_password = ""

  digits = {1:0, 2:0, 3:0, 4:0, 5:0, 6:0, 7:0, 8:0}

  total_time = 0.0

  while reps[0] < reps[1]:
    status = "ongoing"

  current_letter = word_order[0]
  current_letter_index = 0

  if target_password == "":
    reps[0] += 1
    status = "stopped"
    print(status)

  this_time = time.time()
  guesses = 0

  while status == "ongoing":
    guesses+=1
    generate_dictionary_word()

    if reps[1] > 1:
      print(str(all_guesses / reps[1]) + " guesses per password")
      print(str(total_time / reps[1]) + " seconds per password")
      print(str(all_guesses / float(total_time)) + " guesses per second")

def generate_dictionary_word():
  global target_password, current_guess, status, current_letter, current_letter_index, guesses, all_guesses

  if len(words_list[current_letter]) > 0:
    current_guess = words_list[current_letter][current_letter_index]

    if current_letter_index < (len(words_list[current_letter]) - 1):
      current_letter_index+=1

    else:
      if word_order.index(current_letter) < (len(word_order) - 1):
        current_letter = word_order[word_order.index(current_letter) + 1]
        current_letter_index = 0
        print(current_letter)

      else:
        status = "not_found"
        print("DONE: " + current_letter)
        all_guesses += (guesses + 1)
        guesses = 0