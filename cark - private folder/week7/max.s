.section .data          # start of data section

m:      .quad 0


.section .text          # start of text section
        
.global  _start         # make _start symbol visible

_start: 
        pushq %rbp      # save old rbp to stack
        movq %rsp,%rbp  # establish new base pointer
        movq $0x1122334455667788,%rax 
        movq $0x2233445566778899,%rbx
        cmpq %rax,%rbx  # compute rax-rbx <=0 and set eflags
        jle if          # if (rax >= rbx) {
        jmp else
if:     movq %rax,m     #    m = rax 
        jmp endif       # } else {
else:   movq %rbx,m     #    m = rbx
                        # }
endif:  movq m,%rdi     # put m in rdi
        movq $60,%rax   # system call 60 is exit
        leave           # clean up
        syscall         # exit(m)
