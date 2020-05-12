.text
.global my_cmpr_swap


# Parameters:
# rdi: old status
# rsi: cur status
# rdx: mod status
#
# We want to use "lock cmpxchg16b (reg)" instruction
# where reg is some register.
# cmpxchg16b: Compares rdx:rax (as a 128 bit integer) with the 128 
# bit integer starting at address reg.
# We denote this 128 bit integer by m128.
# If rdx:rax equals m128, then the instruction sets the Z flag
# and copies rcx:rbx (as a 128 bit integer) into m128.
# otherwise, it clears the Z flag and copies the m128 into
# the registers rdx:rax.
# 
# VERY IMPORTANT!!! Remember that intel is Little Endian!
#
# This means, the first 64 bits at address reg correspond
# to the lower half (or the lowest 64 bits) of m128!
# This means, when comparing rdx:rax as a 128 bit integer to
# m128, rax is compared to the 64 bit integer at (reg) 
# and rdx is compared to the 64 bit integer at (reg+8).
# Similarly, when rcx:rbx is copied into m128, 
# rbx is copied into the 64 bit integer starting at (reg)
# and rcx is copied into the 64 bit integer at (reg+8)

my_cmpr_swap:
    # First we save rbx,
    # since rbx needs to be used and by 
    # calling conventions, it is our job to save and restore it
    pushq %rbx
	
	movq 8(%rdx),%rcx # first half of modified
	movq (%rdx),%rbx #second half of modified
	movq 8(%rdi),%rdx #first half of old
	movq (%rdi),%rax #second half of old
	# movq %rdi,(%rsi) # first half of current
	# movq %rsi,(%rsi+8) #second half of current
	lock cmpxchg16b (%rsi)
    # you need to figure out which reg to use and how to
    # set up registers rdx:rax, and rcx:rbx
	
    # lock cmpxchg16b (input) compare rdx and rax with input, equals: set ZF put rcx and rbx into input, else: clear ZF load input to rdx and rax

    # If Z flag is set are successful so we return 1.
    # else we return 0
    jz success
    movq $0,%rax
    jmp end

success:
    movq $1,%rax

end:
    popq %rbx
    ret

