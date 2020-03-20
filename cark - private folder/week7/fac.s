.global main              # main is a global symbol

        .section .data            # the place for data
result: .asciz "fac(%llu) = %llu\n" # text to be printed
argc:   .long 0
argv:   .quad 0
a:      .quad 0

        .section .text          # beginning of actual code
main:   pushq %rbp              # save old rbp to stack
        movq %rsp, %rbp         # set new value for rbp
        movl %edi, argc         # save argc
        movq %rsi, argv         # save argv
        movq argv, %rax         # get argv back
        movq 8(%rax), %rdi      # first argument 8-byte aligned
        call atoll               # call atoll
        movq %rax, a            # save a
        movq %rax, %rdi         # first argument
        call fac                # fac(a)
        movq %rax,%rdx          # third argument
        movq a,%rsi             # second argument
        movq $result,%rdi       # first argument
        xor %al,%al             # no vector args
        call printf             # printf("fac(%llu) = %llu\n",a,fac(a))
        xor %rax,%rax           # return code 0 for success
        leave                   # clean up, restore rbp
        ret                     # return / end program

fac:    push %rbp               # save old base pointer
        movq %rsp, %rbp         # establish new base pointer
        subq $16,%rsp           # make room for n
        cmpq $0,%rdi            # if (n == 0)
        je if                   
        jmp else
if:     movq $1, %rax           # we're done, put 1 in rax
        jmp endif
else:   movq %rdi,-8(%rbp)      # save n
        decq %rdi               # rdi = n - 1
        call fac                # rax = fac(n - 1)
        imulq -8(%rbp),%rax     # rax = n*fac(n - 1) (ihvertfald nedre 64 bit)
endif:  leave
        ret
